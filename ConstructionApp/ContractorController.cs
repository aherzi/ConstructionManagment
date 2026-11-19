using ConstructionApp.Shared;
using Microsoft.AspNetCore.Mvc;
namespace ConstructionAppServer
{
    [ApiController]
    [Route("api/contractors")]
    public class ContractorController:ControllerBase
    {
        
        private readonly ContractorService contractorservice;
        public ContractorController(ContractorService service)
        {
            contractorservice = service;
        }
        [HttpPost]
        public IActionResult AssignContractor(
              [FromBody] Site site)
        {
            if (site.contractor == null || site.SiteID <= 0 || site.contractor.ContractorID <= 0)
            {
                return BadRequest("A saved site and contractor are required.");
            }
            bool pass = contractorservice.AddContractor(site,site.contractor);
            if (pass)
            {
                return StatusCode(200, "Assigned Contractor to Site");

            }
            return StatusCode(500, "Failed to assign Contractor to Site");

        }
    }


}

