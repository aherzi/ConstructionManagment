using System.Data.OleDb;
using ConstructionApp.Shared;

namespace ConstructionAppServer
{
    public class SiteDatabase
    {
        private readonly DatabaseManager dbmanager;

        public SiteDatabase(DatabaseManager dbmanager)
        {
            this.dbmanager = dbmanager;
        }

        public bool AddSite(ConstructionSite site)
        {
            using (OleDbConnection connection = dbmanager.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO [Site] ([SiteName], [Address], [OwnerID], [ContractorID], [StartDate]) VALUES (?, ?, ?, ?, ?)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", site.SiteName);
                    command.Parameters.AddWithValue("?", site.Address);
                    command.Parameters.AddWithValue("?", site.OwnerID);
                    command.Parameters.AddWithValue("?", site.ContractorID);
                    command.Parameters.Add("?", OleDbType.Date).Value = site.StartDate;
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<ConstructionSite> GetAllSites()
        {
            List<ConstructionSite> sites = new List<ConstructionSite>();
            using (OleDbConnection connection = dbmanager.GetConnection())
            {
                connection.Open();
                string query = "SELECT [SiteID], [SiteName], [Address], [OwnerID], [ContractorID], [StartDate] FROM [Site]";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ConstructionSite site = new ConstructionSite();
                        site.SiteID = Convert.ToInt32(reader[0]);
                        site.SiteName = reader.IsDBNull(1) ? "" : reader[1].ToString();
                        site.Address = reader.IsDBNull(2) ? "" : reader[2].ToString();
                        site.OwnerID = reader.IsDBNull(3) ? 0 : Convert.ToInt32(reader[3]);
                        site.ContractorID = reader.IsDBNull(4) ? 0 : Convert.ToInt32(reader[4]);
                        site.StartDate = reader.IsDBNull(5) ? DateTime.Today : Convert.ToDateTime(reader[5]);
                        sites.Add(site);
                    }
                }
            }
            return sites;
        }
    }
}
