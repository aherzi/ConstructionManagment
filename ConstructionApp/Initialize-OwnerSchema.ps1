param([string]$DatabasePath)

$ErrorActionPreference = 'Stop'
if ([string]::IsNullOrWhiteSpace($DatabasePath)) {
    $settings = Get-Content -LiteralPath (Join-Path $PSScriptRoot 'appsettings.json') -Raw | ConvertFrom-Json
    $DatabasePath = $settings.Database.Path
    if ([string]::IsNullOrWhiteSpace($DatabasePath)) {
        $DatabasePath = Join-Path $PSScriptRoot 'Construction_Management_DB.accdb'
    }
    elseif (-not [System.IO.Path]::IsPathRooted($DatabasePath)) {
        $DatabasePath = Join-Path $PSScriptRoot $DatabasePath
    }
}
$DatabasePath = (Resolve-Path -LiteralPath $DatabasePath).Path

# Use literal OLE DB keywords. PowerShell's dictionary adapter can treat
# DataSource as a custom keyword instead of the required "Data Source".
$connectionString = New-Object System.Data.Common.DbConnectionStringBuilder
$connectionString['Provider'] = 'Microsoft.ACE.OLEDB.16.0'
$connectionString['Data Source'] = $DatabasePath
$connection = New-Object System.Data.OleDb.OleDbConnection
$connection.ConnectionString = $connectionString.ToString()

function Invoke-SchemaCommand([string]$Sql) {
    $command = $connection.CreateCommand()
    try {
        $command.CommandText = $Sql
        [void]$command.ExecuteNonQuery()
    }
    finally { $command.Dispose() }
}

function Get-ColumnNames([string]$TableName) {
    $connection.GetSchema('Columns', [string[]]@($null, $null, $TableName, $null)).Rows |
        ForEach-Object { [string]$_.COLUMN_NAME }
}

try {
    Write-Output "Opening database: $DatabasePath"
    $connection.Open()
    $tableNames = @($connection.GetSchema('Tables').Rows | ForEach-Object { [string]$_.TABLE_NAME })
    if ($tableNames -notcontains 'UserAccount' -or $tableNames -notcontains 'Site') {
        throw 'The database must already contain UserAccount and Site tables.'
    }

    # Inspect everything before making changes. Never create or backfill owner records here.
    $commands = New-Object 'System.Collections.Generic.List[string]'
    if ($tableNames -notcontains 'Owner') {
        $commands.Add('CREATE TABLE [Owner] ([OwnerID] COUNTER CONSTRAINT [PK_Owner] PRIMARY KEY, [UserID] LONG NOT NULL)')
    }
    else {
        $ownerColumns = @(Get-ColumnNames 'Owner')
        if ($ownerColumns -notcontains 'OwnerID') {
            $commands.Add('ALTER TABLE [Owner] ADD COLUMN [OwnerID] COUNTER')
            $commands.Add('CREATE UNIQUE INDEX [UX_Owner_OwnerID] ON [Owner] ([OwnerID])')
        }
        if ($ownerColumns -notcontains 'UserID') {
            $commands.Add('ALTER TABLE [Owner] ADD COLUMN [UserID] LONG')
        }
    }
    if (@(Get-ColumnNames 'Site') -notcontains 'OwnerID') {
        $commands.Add('ALTER TABLE [Site] ADD COLUMN [OwnerID] LONG')
    }

    if ($commands.Count -eq 0) {
        Write-Output 'OwnerID, UserID, and Site.OwnerID are already present. No changes needed.'
        return
    }

    # Close the connection before copying the database. Close Access and stop the server before running.
    $connection.Close()
    $backupPath = "$DatabasePath.owner-schema-backup-$(Get-Date -Format 'yyyyMMdd-HHmmss-fff').accdb"
    Copy-Item -LiteralPath $DatabasePath -Destination $backupPath -ErrorAction Stop
    Write-Output "Backup: $backupPath"
    $connection.Open()
    foreach ($sql in $commands) {
        Write-Output $sql
        Invoke-SchemaCommand $sql
    }
    Write-Output 'Owner schema is ready. Existing owner accounts were not backfilled.'
}
finally { $connection.Dispose() }
