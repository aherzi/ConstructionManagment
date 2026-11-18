using System.Data.OleDb;
using ConstructionApp.Shared;

namespace ConstructionAppServer
{
    public class PhaseDatabase
    {
        private readonly DatabaseManager dbmanager;

        public PhaseDatabase(DatabaseManager dbmanager)
        {
            this.dbmanager = dbmanager;
        }

        public bool AddPhase(ConstructionPhase phase)
        {
            using (OleDbConnection connection = dbmanager.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO [Phase] ([SiteID], [Stage], [Description], [PlannedStart], [PlannedEnd], [PercentComplete]) VALUES (?, ?, ?, ?, ?, ?)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", phase.SiteID);
                    command.Parameters.AddWithValue("?", phase.Stage);
                    command.Parameters.AddWithValue("?", phase.Description ?? "");
                    command.Parameters.Add("?", OleDbType.Date).Value = phase.PlannedStart;
                    command.Parameters.Add("?", OleDbType.Date).Value = phase.PlannedEnd;
                    command.Parameters.AddWithValue("?", phase.PercentComplete);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdatePhase(ConstructionPhase phase)
        {
            using (OleDbConnection connection = dbmanager.GetConnection())
            {
                connection.Open();
                string query = "UPDATE [Phase] SET [Stage] = ?, [Description] = ?, [PlannedStart] = ?, [PlannedEnd] = ?, [PercentComplete] = ? WHERE [PhaseID] = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", phase.Stage);
                    command.Parameters.AddWithValue("?", phase.Description ?? "");
                    command.Parameters.Add("?", OleDbType.Date).Value = phase.PlannedStart;
                    command.Parameters.Add("?", OleDbType.Date).Value = phase.PlannedEnd;
                    command.Parameters.AddWithValue("?", phase.PercentComplete);
                    command.Parameters.AddWithValue("?", phase.PhaseID);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<ConstructionPhase> GetPhasesBySite(int siteId)
        {
            List<ConstructionPhase> phases = new List<ConstructionPhase>();
            using (OleDbConnection connection = dbmanager.GetConnection())
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
                            ConstructionPhase phase = new ConstructionPhase();
                            phase.PhaseID = Convert.ToInt32(reader[0]);
                            phase.SiteID = Convert.ToInt32(reader[1]);
                            phase.Stage = reader.IsDBNull(2) ? "" : reader[2].ToString();
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
    }
}
