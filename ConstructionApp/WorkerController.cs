using ConstructionApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAppServer
{
 
        [ApiController]
        [Route("api/workers")]

        public class WorkersController : ControllerBase
        {
            private readonly DatabaseManager dbmanager;
            public WorkersController(DatabaseManager maanger)
            {
                dbmanager = maanger;
            }
            [HttpGet]
           

            public IActionResult GetWorkers()
            {
                // Retrieve workers from your database
                List<Worker> workers = dbmanager.GetAllWorkers();

                return Ok(workers);
            }
        }
    }

