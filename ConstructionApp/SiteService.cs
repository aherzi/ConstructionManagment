namespace ConstructionAppServer
{
    using ConstructionApp.Shared;
    using Microsoft.AspNetCore.Mvc;

    public class SiteService
    {
        DatabaseManager dbmanager = new DatabaseManager();
        public async Task<IActionResult> CreateSite(Site site)
        {
            dbmanager.CreateSite(site);
            return new OkResult();
        }
    }
}
