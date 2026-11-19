namespace ConstructionAppServer
{
    using ConstructionApp.Shared;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.AspNetCore.Mvc;
    

    public class SiteService
    {

        private readonly DatabaseManager dbmanager;
        public SiteService(DatabaseManager manager)
        {
            dbmanager = manager;

        }
        public bool AddSite(Site site)
        {
            return dbmanager.CreateSite(site);
        }
        public List<Site> GetContractorSites(int contractorId)
        {
            return dbmanager.GetContractorSites(contractorId);
        }
        }
        
    }

