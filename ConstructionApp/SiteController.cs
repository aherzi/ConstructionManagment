using ConstructionApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAppServer
{
    
        [ApiController]
        [Route("api/sites")]
        public class SiteController : ControllerBase
        {
            private readonly SiteService _siteService;

            public SiteController(SiteService siteService)
            {
                _siteService = siteService;
            }

            [HttpPost]
            public  IActionResult CreateSite(
                [FromBody] Site site)
            {
                if (site.contractor == null || site.contractor.ContractorID <= 0)
                    return BadRequest("A valid contractor is required.");
                if (string.IsNullOrWhiteSpace(site.SiteName) || string.IsNullOrWhiteSpace(site.Address))
                    return BadRequest("Site name and address are required.");
                if (site.StartDate == default) site.StartDate = DateTime.Today;
                if (site.DateCreated == default) site.DateCreated = DateTime.Now;
                 bool pass=_siteService.AddSite(site);
                if (pass)
                {
                    return Ok(site);

                }
                return StatusCode(500, "Failed to create Site");

            }

            [HttpGet("contractor/{contractorId:int}")]
            public IActionResult GetContractorSites(int contractorId)
            {
                if (contractorId <= 0) return BadRequest("A valid contractor is required.");
                try
                {
                    return Ok(_siteService.GetContractorSites(contractorId));
                }
                catch (InvalidOperationException ex)
                {
                    return Problem(detail: ex.Message);
                }
            }
        }

       
    }

