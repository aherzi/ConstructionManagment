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
        public Contractor? GetContractor(User user)
        {
            return dbmanager.GetContractor(user);
        }
        public Worker? GetWorker(int worker)
        {
            return dbmanager.GetWorker(worker);
        }
        public bool AssignWorker(int siteid,int workerid)
        {
            return dbmanager.AssignWorkerToSite(siteid, workerid);
        }

        public int GetRole(User user)
        {
            return dbmanager.GetRole(user);
        }


        public List<AssignedSite> GetAssignedSites(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.username) || string.IsNullOrEmpty(user.password))
            {
                throw new ArgumentException("Sign in to view your assigned sites.");
            }
            return dbmanager.GetAssignedSites(user);
        }
    }
}
