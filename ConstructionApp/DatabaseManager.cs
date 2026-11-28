using ConstructionApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using static ConstructionApp.Shared.Phase;
namespace ConstructionAppServer

{

    public class DatabaseManager
    {
        private readonly string databasePath;

        public DatabaseManager(IConfiguration configuration, IWebHostEnvironment environment)
        {
            databasePath = Path.GetFullPath(configuration["Database:Path"]
                ?? Path.Combine(environment.ContentRootPath, "Construction_Management_DB.accdb"), environment.ContentRootPath);
            if (!File.Exists(databasePath))
                throw new FileNotFoundException("The configured Access database was not found.", databasePath);
        }

        public OleDbConnection GetConnection()
        {
            string connectionString = new OleDbConnectionStringBuilder
            {
                Provider = "Microsoft.ACE.OLEDB.16.0",
                DataSource = databasePath
            }.ConnectionString;
            return new OleDbConnection(connectionString);
        }
        public void CloseConnection(OleDbConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public bool UserExists(User user)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM UserAccount WHERE Email = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", user.email);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool RegisterUser(User user)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                using (OleDbTransaction transaction = connection.BeginTransaction())
                {
                    using (OleDbCommand command = new OleDbCommand(
                        "INSERT INTO UserAccount ([Username], [Password], [Email], [Role]) VALUES (?, ?, ?, ?)", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Username", user.username);
                        command.Parameters.AddWithValue("@Password", user.password);
                        command.Parameters.AddWithValue("@Email", user.email);
                        command.Parameters.Add("@Role", OleDbType.Integer).Value = (int)user.role;
                        if (command.ExecuteNonQuery() != 1) return false;
                    }
                    using (OleDbCommand identity = new OleDbCommand("SELECT @@IDENTITY", connection, transaction))
                    {
                        user.userid = Convert.ToInt32(identity.ExecuteScalar());
                    }
                    if (user.role == User.Role.Contractor)
                    {
                        GetOrCreateContractorID(connection, transaction, user.userid);

                    }
                    else if (user.role == User.Role.Worker)
                    {
                        GetOrCreateWorkerID(connection, transaction, user.userid);
                    }
                    else if (user.role == User.Role.Owner)
                    {
                        GetOrCreateOwnerID(connection, transaction, user.userid);
                    }
                    transaction.Commit();

                    return true;
                }
            }
        }

        private static int GetOrCreateContractorID(OleDbConnection connection, OleDbTransaction transaction, int userId)
        {
            using (OleDbCommand lookup = new OleDbCommand(
                "SELECT [ContractorID] FROM Contractor WHERE [UserID] = ?", connection, transaction))
            {
                lookup.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                object? existingId = lookup.ExecuteScalar();
                if (existingId != null && existingId != DBNull.Value)
                    return Convert.ToInt32(existingId);
            }
            using (OleDbCommand insert = new OleDbCommand(
                "INSERT INTO Contractor ([UserID]) VALUES (?)", connection, transaction))
            {
                insert.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                insert.ExecuteNonQuery();
            }
            using (OleDbCommand identity = new OleDbCommand("SELECT @@IDENTITY", connection, transaction))
            {
                return Convert.ToInt32(identity.ExecuteScalar());
            }
        }
        private static int GetOrCreateWorkerID(OleDbConnection connection, OleDbTransaction transaction, int userId)
        {
            using (OleDbCommand lookup = new OleDbCommand(
                "SELECT [WorkerID] FROM Worker WHERE [UserID] = ?", connection, transaction))
            {
                lookup.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                object? existingId = lookup.ExecuteScalar();
                if (existingId != null && existingId != DBNull.Value)
                    return Convert.ToInt32(existingId);
            }
            using (OleDbCommand insert = new OleDbCommand(
                "INSERT INTO Worker ([UserID]) VALUES (?)", connection, transaction))
            {
                insert.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                insert.ExecuteNonQuery();
            }
            using (OleDbCommand identity = new OleDbCommand("SELECT @@IDENTITY", connection, transaction))
            {
                return Convert.ToInt32(identity.ExecuteScalar());
            }
        }
        private static int GetOrCreateOwnerID(OleDbConnection connection, OleDbTransaction transaction, int userId)
        {
            using (OleDbCommand lookup = new OleDbCommand(
                "SELECT [OwnerID] FROM [Owner] WHERE [UserID] = ?", connection, transaction))
            {
                lookup.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                object existingId = lookup.ExecuteScalar();
                if (existingId != null && existingId != DBNull.Value)
                    return Convert.ToInt32(existingId);
            }
            using (OleDbCommand insert = new OleDbCommand(
                "INSERT INTO [Owner] ([UserID]) VALUES (?)", connection, transaction))
            {
                insert.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                insert.ExecuteNonQuery();
            }
            using (OleDbCommand identity = new OleDbCommand("SELECT @@IDENTITY", connection, transaction))
            {
                return Convert.ToInt32(identity.ExecuteScalar());
            }
        }

        public List<Owner> GetAllOwners()
        {
            List<Owner> owners = new List<Owner>();
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                const string query = "SELECT o.[OwnerID], u.[UserID], u.[Username] " +
                    "FROM [Owner] AS o INNER JOIN [UserAccount] AS u ON o.[UserID] = u.[UserID] " +
                    "WHERE u.[Role] = ? ORDER BY u.[Username], o.[OwnerID]";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("@Role", OleDbType.Integer).Value = (int)User.Role.Owner;
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            owners.Add(new Owner
                            {
                                OwnerID = Convert.ToInt32(reader["OwnerID"]),
                                userid = Convert.ToInt32(reader["UserID"]),
                                username = Convert.ToString(reader["Username"]),
                                role = User.Role.Owner
                            });
                        }
                    }
                }
            }
            return owners;
        }

        public bool VerifyUser(User user)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM UserAccount WHERE ([Username]=@Username AND [Password]=@Password) ";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.username);
                    command.Parameters.AddWithValue("@Password", user.password);
                    int count = Convert.ToInt32(command.ExecuteScalar());    
                    return count > 0;
                }
            }
        }
        public int GetRole(User user)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT Role FROM UserAccount WHERE ([Username]=@Username AND [Password]=@Password) ";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.username);
                    command.Parameters.AddWithValue("@Password", user.password);
                    int role = Convert.ToInt32(command.ExecuteScalar());
                    return role;
                }
            }

        }
        public Boolean CreateSite(Site site)
        {
            if (site.owner == null || site.owner.OwnerID <= 0)
                throw new ArgumentException("Select a property owner.", nameof(site));
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                using (OleDbCommand ownerLookup = new OleDbCommand(
                    "SELECT COUNT(*) FROM [Owner] AS o INNER JOIN [UserAccount] AS u ON o.[UserID] = u.[UserID] " +
                    "WHERE o.[OwnerID] = ? AND u.[Role] = ?", connection))
                {
                    ownerLookup.Parameters.Add("@OwnerID", OleDbType.Integer).Value = site.owner.OwnerID;
                    ownerLookup.Parameters.Add("@Role", OleDbType.Integer).Value = (int)User.Role.Owner;
                    if (Convert.ToInt32(ownerLookup.ExecuteScalar()) == 0)
                        throw new ArgumentException("The selected property owner does not exist.", nameof(site));
                }
                string query = "INSERT INTO Site ([ContractorID],[SiteName],[Address],[StartDate],[EstimatedCompletionDate],[Zoning],[Description],[DateCreated],[OwnerID]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("@ContractorID", OleDbType.Integer).Value = site.contractor.ContractorID;
                    command.Parameters.Add("@SiteName", OleDbType.VarWChar).Value = site.SiteName;
                    command.Parameters.Add("@Address", OleDbType.VarWChar).Value = site.Address;
                    command.Parameters.Add("@StartDate", OleDbType.Date).Value = site.StartDate;
                    command.Parameters.Add("@EstimatedCompletionDate", OleDbType.Date).Value = site.EstimatedCompletionDate;
                    command.Parameters.Add("@Zoning", OleDbType.Integer).Value = (int)site.zoning;
                    command.Parameters.Add("@Description", OleDbType.LongVarWChar).Value = site.Description ?? "";
                    command.Parameters.Add("@DateCreated", OleDbType.Date).Value = site.DateCreated;
                    command.Parameters.Add("@OwnerID", OleDbType.Integer).Value = site.owner.OwnerID;
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        using (OleDbCommand identity = new OleDbCommand("SELECT @@IDENTITY", connection))
                        {
                            site.SiteID = Convert.ToInt32(identity.ExecuteScalar());
                        }
                    }
                    return rowsAffected > 0;
                }
            }
        }
        public Contractor? GetContractor(User user)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                using (OleDbTransaction transaction = connection.BeginTransaction())
                {
                    Contractor contractor;
                    using (OleDbCommand command = new OleDbCommand(
                        "SELECT [UserID], [Username] FROM UserAccount WHERE [Username] = ? AND [Password] = ? AND [Role] = ?", connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Username", user.username);
                        command.Parameters.AddWithValue("@Password", user.password);
                        command.Parameters.Add("@Role", OleDbType.Integer).Value = (int)User.Role.Contractor;
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read()) return null;
                            contractor = new Contractor
                            {
                                userid = Convert.ToInt32(reader["UserID"]),
                                username = Convert.ToString(reader["Username"]),
                                role = User.Role.Contractor
                            };
                        }
                    }
                    contractor.ContractorID = GetOrCreateContractorID(connection, transaction, contractor.userid);
                    transaction.Commit();
                    return contractor;
                }
            }
        }
        public Worker? GetWorker(int workerId)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();

                string query =
                    "SELECT w.[WorkerID], u.[UserID], u.[Username] " +
                    "FROM [Worker] AS w " +
                    "INNER JOIN [UserAccount] AS u ON w.[UserID] = u.[UserID] " +
                    "WHERE w.[WorkerID] = ? AND u.[Role] = ?";

                using (OleDbCommand command =
                    new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("@WorkerID", OleDbType.Integer)
                        .Value = workerId;
                    command.Parameters.Add("@Role", OleDbType.Integer)
                        .Value = (int)User.Role.Worker;

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        return new Worker
                        {
                            WorkerID = Convert.ToInt32(reader["WorkerID"]),
                            userid = Convert.ToInt32(reader["UserID"]),
                            username = Convert.ToString(reader["Username"]),
                            role = User.Role.Worker
                        };
                    }
                }
            }
        }
        public bool AssignWorkerToSite(int siteId, int workerId)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();

                string query = "INSERT INTO [AssignedWorker] " + "([WorkerID], [SiteID], [DateAssigned], [AssignmentStatus]) " +
                "VALUES (?, ?, ?, ?)";

                using (OleDbCommand command =
                    new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("@WorkerID", OleDbType.Integer).Value = workerId;

                    command.Parameters.Add("@SiteID", OleDbType.Integer)
                        .Value = siteId;

                    command.Parameters.Add("@DateAssigned", OleDbType.Date)
                        .Value = DateTime.Now;

                    command.Parameters.Add("@AssignmentStatus", OleDbType.VarWChar)
                        .Value = "Assigned";


                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<Site> GetContractorSites(int contractorId)
        {
            var sites = new List<Site>();
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                ValidateSiteColumns(connection);
                using (OleDbCommand command = new OleDbCommand(
                    "SELECT [SiteID], [SiteName], [Address], [StartDate], [EstimatedCompletionDate], [Zoning], [Description], [DateCreated], [OwnerID] FROM [Site] WHERE [ContractorID] = ? ORDER BY [SiteID] DESC", connection))
                {
                    command.Parameters.Add("@ContractorID", OleDbType.Integer).Value = contractorId;
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sites.Add(new Site
                            {
                                SiteID = Convert.ToInt32(reader["SiteID"]),
                                SiteName = Convert.ToString(reader["SiteName"]),
                                Address = Convert.ToString(reader["Address"]),
                                StartDate = reader["StartDate"] == DBNull.Value ? default : Convert.ToDateTime(reader["StartDate"]),
                                EstimatedCompletionDate = Convert.ToDateTime(reader["EstimatedCompletionDate"]),
                                DateCreated = reader["DateCreated"] == DBNull.Value ? default : Convert.ToDateTime(reader["DateCreated"]),
                                zoning = reader["Zoning"] == DBNull.Value ? default : (Site.Zoning)Convert.ToInt32(reader["Zoning"]),
                                Description = Convert.ToString(reader["Description"]),
                                contractor = new Contractor { ContractorID = contractorId },
                                owner = reader["OwnerID"] == DBNull.Value ? null : new Owner { OwnerID = Convert.ToInt32(reader["OwnerID"]) },
                                workers = new List<Worker>()
                            });
                        }
                    }
                }
            }
            return sites;
        }

        private void ValidateSiteColumns(OleDbConnection connection)
        {
            var columns = connection.GetSchema("Columns", new string?[] { null, null, "Site", null });
            var actual = columns.Rows.Cast<System.Data.DataRow>()
                .Select(row => Convert.ToString(row["COLUMN_NAME"]) ?? "")
                .ToArray();
            string[] required = { "SiteID", "SiteName", "Address", "StartDate", "EstimatedCompletionDate", "Zoning", "Description", "DateCreated", "ContractorID", "OwnerID" };
            var missing = required.Except(actual, StringComparer.OrdinalIgnoreCase).ToArray();
            if (missing.Length > 0)
            {
                throw new InvalidOperationException(
                    $"The Site table in '{databasePath}' is missing these fields: {string.Join(", ", missing)}. " +
                    $"Actual fields: {string.Join(", ", actual)}.");
            }
        }

        public bool AssignContractorToSite(int siteId, int contractorId)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();

                string query =
                    "UPDATE Site SET ContractorID = ? WHERE SiteID = ?";

                using (OleDbCommand command =
                    new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", contractorId);
                    command.Parameters.AddWithValue("?", siteId);

                    return command.ExecuteNonQuery() > 0;
                }
            }

        }
        public List<Worker> GetAllWorkers()
        {
            List<Worker> workers = new List<Worker>();

            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();

                string query = @"
            SELECT Worker.WorkerID, UserAccount.Username
            FROM Worker
            INNER JOIN UserAccount
            ON Worker.UserID = UserAccount.UserID";

                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Worker worker = new Worker
                        {
                            WorkerID = Convert.ToInt32(reader["WorkerID"]),
                            username = reader["Username"].ToString()
                        };

                        workers.Add(worker);
                    }
                }
            }

            return workers;
        }
        public bool AddPhase(Phase phase)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO [Phase] ([SiteID], [Stage], [Description], [PlannedStart], [PlannedEnd], [PercentComplete]) VALUES (?, ?, ?, ?, ?, ?)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", phase.site.SiteID);
                    command.Parameters.AddWithValue("?", phase.stage);
                    command.Parameters.AddWithValue("?", phase.Description ?? "");
                    command.Parameters.Add("?", OleDbType.Date).Value = phase.PlannedStart;
                    command.Parameters.Add("?", OleDbType.Date).Value = phase.PlannedEnd;
                    command.Parameters.AddWithValue("?", phase.PercentComplete);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdatePhase(Phase phase)
        {
            using (OleDbConnection connection =GetConnection())
            {
                connection.Open();
                string query = "UPDATE [Phase] SET [Stage] = ?, [Description] = ?, [PlannedStart] = ?, [PlannedEnd] = ?, [PercentComplete] = ? WHERE [PhaseID] = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", phase.stage);
                    command.Parameters.AddWithValue("?", phase.Description ?? "");
                    command.Parameters.Add("?", OleDbType.Date).Value = phase.PlannedStart;
                    command.Parameters.Add("?", OleDbType.Date).Value = phase.PlannedEnd;
                    command.Parameters.AddWithValue("?", phase.PercentComplete);
                    command.Parameters.AddWithValue("?", phase.PhaseID);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Phase> GetPhasesBySite(int siteId)
        {
            List<Phase> phases = new List<Phase>();
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT [PhaseID], [SiteID], [Stage], [Description], [PlannedStart], [PlannedEnd], [PercentComplete] FROM [Phase] WHERE [SiteID] = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", siteId);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Phase phase = new Phase();
                            phase.PhaseID = Convert.ToInt32(reader[0]);
                            phase.site.SiteID = Convert.ToInt32(reader[1]);

                            if (!reader.IsDBNull(2))
                            {
                                phase.stage = (Phase.Stage)Enum.Parse(
                                    typeof(Phase.Stage),
                                    reader[2].ToString(),
                                    true);
                            }

                          

                            phase.Description = reader.IsDBNull(3) ? "" : reader[3].ToString();
                            phase.PlannedStart = reader.IsDBNull(4) ? DateTime.Today : Convert.ToDateTime(reader[4]);
                            phase.PlannedEnd = reader.IsDBNull(5) ? DateTime.Today : Convert.ToDateTime(reader[5]);
                            phase.PercentComplete = reader.IsDBNull(6) ? 0 : Convert.ToInt32(reader[6]);
                            phases.Add(phase);
                        }
                    }
                }
            }
            return phases;
        }
        public bool AddSite(Site site)
        {
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO [Site] ([SiteName], [Address], [OwnerID], [ContractorID], [StartDate]) VALUES (?, ?, ?, ?, ?)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", site.SiteName);
                    command.Parameters.AddWithValue("?", site.Address);
                    command.Parameters.AddWithValue("?", site.owner.OwnerID);
                    command.Parameters.AddWithValue("?", site.contractor.ContractorID);
                    command.Parameters.Add("?", OleDbType.Date).Value = site.StartDate;
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Site> GetAllSites()
        {
            List<Site> sites = new List<Site>();
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT [SiteID], [SiteName], [Address], [OwnerID], [ContractorID], [StartDate] FROM [Site]";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Site site = new Site();
                        site.SiteID = Convert.ToInt32(reader[0]);
                        site.SiteName = reader.IsDBNull(1) ? "" : reader[1].ToString();
                        site.Address = reader.IsDBNull(2) ? "" : reader[2].ToString();
                        site.owner = reader.IsDBNull(3) ? null : new Owner { OwnerID = Convert.ToInt32(reader[3]) };
                        site.contractor = reader.IsDBNull(4) ? null : new Contractor { ContractorID = Convert.ToInt32(reader[4]) };
                        site.StartDate = reader.IsDBNull(5) ? DateTime.Today : Convert.ToDateTime(reader[5]);
                        sites.Add(site);
                    }
                }
            }
            return sites;
        }

        public List<AssignedSite> GetAssignedSites(User user)
        {
            var sites = new List<AssignedSite>();
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                // WorkerID belongs to Worker, not UserAccount. Include every assignment status.
                const string query = @"
                    SELECT s.[SiteID], s.[SiteName], s.[Address],
                           a.[DateAssigned], a.[AssignmentStatus]
                    FROM (([Site] AS s
                    INNER JOIN [AssignedWorker] AS a ON s.[SiteID] = a.[SiteID])
                    INNER JOIN [Worker] AS w ON a.[WorkerID] = w.[WorkerID])
                    INNER JOIN [UserAccount] AS u ON w.[UserID] = u.[UserID]
                    WHERE u.[Username] = ? AND u.[Password] = ? AND u.[Role] = ?
                    ORDER BY s.[SiteName], s.[SiteID]";
                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.username);
                    command.Parameters.AddWithValue("@Password", user.password);
                    command.Parameters.AddWithValue("@Role", (int)User.Role.Worker);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sites.Add(new AssignedSite
                            {
                                SiteId = Convert.ToInt32(reader["SiteID"]),
                                SiteName = Convert.ToString(reader["SiteName"]) ?? string.Empty,
                                Address = Convert.ToString(reader["Address"]) ?? string.Empty,
                                DateAssigned = reader["DateAssigned"] == DBNull.Value
                                    ? (DateTime?)null : Convert.ToDateTime(reader["DateAssigned"]),
                                AssignmentStatus = Convert.ToString(reader["AssignmentStatus"]) ?? string.Empty
                            });
                        }
                    }
                }
            }
            return sites;
        }
    }
}
