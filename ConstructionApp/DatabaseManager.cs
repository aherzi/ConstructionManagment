using System;
using System.Data.OleDb;
using System.Collections.Generic;
using ConstructionApp.Shared;
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
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Site ([ContractorID],[SiteName],[Address],[StartDate],[EstimatedCompletionDate],[Zoning],[Description],[DateCreated]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
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
        public List<Site> GetContractorSites(int contractorId)
        {
            var sites = new List<Site>();
            using (OleDbConnection connection = GetConnection())
            {
                connection.Open();
                ValidateSiteColumns(connection);
                using (OleDbCommand command = new OleDbCommand(
                    "SELECT [SiteID], [SiteName], [Address], [StartDate], [EstimatedCompletionDate], [Zoning], [Description], [DateCreated] FROM [Site] WHERE [ContractorID] = ? ORDER BY [SiteID] DESC", connection))
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
            string[] required = { "SiteID", "SiteName", "Address", "StartDate", "EstimatedCompletionDate", "Zoning", "Description", "DateCreated", "ContractorID" };
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

    }
}
