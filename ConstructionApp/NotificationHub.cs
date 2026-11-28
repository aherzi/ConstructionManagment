using ConstructionApp.Shared;

namespace ConstructionAppServer

{
    using Microsoft.AspNetCore.SignalR;
    using System.Collections.Generic;
    using ConstructionApp.Shared;
    using Microsoft.AspNetCore.SignalR.Client;

    public class NotificationHub : Hub
    {
        private readonly DatabaseManager dbmanager;
        private readonly UserService UserService;


        public NotificationHub(
            UserService userservice,
            DatabaseManager dbmanager)
        {
            this.UserService = userservice;
            this.dbmanager = dbmanager;
        }
        

        public async Task SendTestMessage(string message)
        {
            await Clients.All.SendAsync("RecieveNotification", message);
        }

        public bool RegisterUser(User user)
        {
            return UserService.Register(user);



        }
        public bool UserExists(User user)
        {
            return UserService.UserExists(user);

        }
        public bool VerifyUser(User user)
        {
            return UserService.UserVerify(user);
        }
        public Contractor? GetContractor(User user)
        {
            return UserService.GetContractor(user);
        }

        public int GetRole(User user)
        {
            return UserService.GetRole(user);
        }
        public List<Site> GetAllSites()
        {
            return dbmanager.GetAllSites();
        }

        public List<Phase> GetPhasesBySite(int siteId)
        {
            return dbmanager.GetPhasesBySite(siteId);
        }

        public bool AddPhase(Phase phase)
        {
            return dbmanager.AddPhase(phase);
        }

        public bool UpdatePhase(Phase phase)
        {
            return dbmanager.UpdatePhase(phase);
        }
        public async Task<bool> AssignWorkerToSite(User user,
    int siteId, int workerId)
        {
            Contractor contractor = UserService.GetContractor(user);

            if (contractor == null)
            {
                throw new HubException("A valid contractor login is required.");
            }

            List<Site> sites =
                dbmanager.GetContractorSites(contractor.ContractorID);

            if (!sites.Any(site => site.SiteID == siteId))
            {
                throw new HubException(
                    "You can only assign workers to your own sites.");
            }
            Worker worker = UserService.GetWorker(workerId);
            if (worker == null)
            {
                throw new HubException("The selected worker could not be found.");
            }
            // Save the assignment.
            // Notify the worker after saving.
            bool success= UserService.AssignWorker(siteId, workerId);
            if (success) {
                await Clients.User(worker.userid.ToString()).SendAsync("SiteAssigned", siteId);
                    }
            return success;


            
        }
        public List<AssignedSite> GetAssignedSites(User user)
        {
            return UserService.GetAssignedSites(user);
        }
    }
}

