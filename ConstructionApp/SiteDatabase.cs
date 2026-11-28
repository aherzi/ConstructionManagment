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

        public bool AddSite(Site site)
        {
            using (OleDbConnection connection = dbmanager.GetConnection())
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
            using (OleDbConnection connection = dbmanager.GetConnection())
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
    }
}
