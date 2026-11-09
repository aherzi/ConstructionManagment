using ConstructionApp.Shared;
namespace ConstructionAppServer
{
    public class UserService
    {
        private readonly DatabaseManager dbmanager;
        public UserService(DatabaseManager dbmanager)
        {
            this.dbmanager = dbmanager;
        }
        public bool Register(User user)
        {
            if (dbmanager.UserExists(user))
            {
                return false; // User already exists
            }
            else
            {
                return dbmanager.RegisterUser(user);
            }
        }
        public bool UserExists(User user)
        {
            return dbmanager.UserExists(user);
        }
        public bool UserVerify(User user)
        {
            return dbmanager.VerifyUser( user);
        }
        public int GetRole(User user)
        {
            return dbmanager.GetRole(user);
        }


    }
}
