# ConstructionApp

Construction management application with an ASP.NET Core server, a Windows Forms client, and shared models.

## Open the solution

Open `ConstructionApp/ConstructionApp.slnx` in Visual Studio with the ASP.NET and web development and .NET desktop development workloads. The server targets .NET 10, the client targets .NET Framework 4.8, and shared models target .NET Standard 2.0.

Restore NuGet packages before building. The client expects packages under `ConstructionApp/packages`; use that folder as the package restore destination for `ConstructionAppClient/packages.config`.

## Database

The server uses Microsoft Access through the Microsoft.ACE.OLEDB.16.0 provider and expects `Construction_Management_DB.accdb` in its working directory. Supply your local database and install the matching Access Database Engine provider. Database files are excluded from Git because they can contain user accounts and application data.

## Run

Start the server and the Windows Forms client from Visual Studio. Configure their startup projects as needed.

## Property owners when creating a site

Close Microsoft Access and stop the server, then run `ConstructionApp/Initialize-OwnerSchema.ps1` in Windows PowerShell. The script uses the database path in `appsettings.json` (or accepts `-DatabasePath`), backs up the database before making changes, and adds missing `Owner.OwnerID` (AutoNumber), `Owner.UserID`, and `Site.OwnerID` fields. It does not create owner records for existing login accounts.

New accounts registered with the Owner role create a linked Owner record in the same transaction as their login account. The contractor's Create Site form loads usernames from `GET /api/owners`, requires an owner selection, and saves that owner's ID with the site. Existing accounts without an Owner row are not included.
