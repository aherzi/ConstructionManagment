using ConstructionApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAppServer
{
    [ApiController]
    [Route("api/sites")]
    public class SitesController : ControllerBase
    {
        private readonly SiteService siteservice;

        public SitesController(SiteService siteService)
        {
            siteservice = siteService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSite(Site site)
        {
            await siteservice.CreateSite(site);

            return Ok();
        }
    }
}
