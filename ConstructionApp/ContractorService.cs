using ConstructionApp.Shared;

namespace ConstructionAppServer
{
    public class ContractorService
    {
        private readonly DatabaseManager dbmanager;
        public ContractorService(DatabaseManager manager)
        {
            dbmanager = manager;

        }
        public bool AddContractor(Site site,Contractor contractor)
        {
            return dbmanager.AssignContractorToSite(site.SiteID,contractor.ContractorID);
        }
    }
}

