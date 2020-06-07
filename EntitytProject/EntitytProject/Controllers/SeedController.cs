using EntitytProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitytProject.Controllers
{
    [Route("api/seed")]
    [ApiController]
    public class SeedController : ControllerBase
    {

        private readonly ISeedService seedService;

        public SeedController(ISeedService seedService)
        {
            this.seedService = seedService;
        }

        [HttpGet]
        public IActionResult seed()
        {
            return Ok(seedService.seedDataBase());
        }


    }
}
