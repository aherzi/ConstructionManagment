using Microsoft.AspNetCore.Mvc;

namespace ConstructionAppServer
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersController : ControllerBase
    {
        private readonly DatabaseManager dbmanager;

        public OwnersController(DatabaseManager dbmanager)
        {
            this.dbmanager = dbmanager;
        }

        [HttpGet]
        public IActionResult GetOwners()
        {
            return Ok(dbmanager.GetAllOwners());
        }
    }
}
