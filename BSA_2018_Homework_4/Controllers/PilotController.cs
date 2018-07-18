using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.Controllers
{
    //[Produces("application/json")]
    [Route("api/Pilot")]
    public class PilotController : Controller
    {
		private IPilotService pilotService;

		public PilotController(IPilotService pilotService)
		{
			this.pilotService = pilotService;
		}

        // GET: api/Pilot
        [HttpGet]
        //public IEnumerable<PilotDTO> Get()
		public async Task<IActionResult> Get()
        {
			List<PilotDTO> temp = await pilotService.GetPilotCollection();

			if (temp != null)
				return Ok(temp);
			else
				return NotFound(temp);

			//return temp;
        }

        // GET: api/Pilot/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PilotDTO temp = await pilotService.GetPilotById(id);

			if (temp != null)
				return Ok(temp);
			else
				return NotFound(temp);

			//return temp;
		}
        
        // POST: api/Pilot
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PilotDTO pilot)
        {
			if (ModelState.IsValid && pilot != null)
			{				
				await pilotService.CreatePilot(pilot);
				return Ok(pilot);
			}
			else
			{
				return BadRequest();
			}
		}
        
        // PUT: api/Pilot/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PilotDTO pilot)
        {
			if (ModelState.IsValid)
			{				
				await pilotService.UpdatePilot(id, pilot);
				return Ok();
			}
			else
			{
				return BadRequest();
			}		
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
			await pilotService.DeletePilotById(id);
        }
    }
}
