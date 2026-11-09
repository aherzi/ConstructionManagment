using System;
using System.Data.OleDb;
using ConstructionApp.Shared;
namespace ConstructionAppServer
{

    public class DatabaseManager
    {
        public OleDbConnection GetConnection()
        {


            try
            {

                string strConnection = "provider=Microsoft.ACE.OLEDB.16.0;" + "Data Source=Construction_Management_DB.accdb";
                OleDbConnection myConnection = new OleDbConnection(strConnection);



                return myConnection;

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Error: " + ex.Message);
            }
            return null;


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
                string query = "INSERT INTO UserAccount ([Username], [Password], [Email], [Role]) VALUES (?, ?, ?, ?)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.username);
                    command.Parameters.AddWithValue("@Password", user.password);
                    command.Parameters.AddWithValue("@Email", user.email);
                    command.Parameters.AddWithValue("@Role", user.role);
                    int rowsAffected = command.ExecuteNonQuery();
                    
                    return rowsAffected > 0;
                }
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
    }
}
