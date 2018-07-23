using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DTOs;
using BSA_2018_Homework_4.DTOs.InputDTOs;

namespace BSA_2018_Homework_4.Controllers
{ 
    //[Produces("application/json")]
    [Route("api/Crew")]
    public class CrewController : Controller
    {
		private ICrewService crewService;

		public CrewController(ICrewService crewService)
		{
			this.crewService = crewService;
		}

        // GET: api/Crew
        [HttpGet]
        public async Task<IActionResult> Get()
        {
			List<CrewDTO> temp = await crewService.GetCrewCollection();

			if (temp != null)
				return Ok(temp);
			else
				return BadRequest();
		}

        // GET: api/Crew/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CrewDTO temp = await crewService.GetCrewById(id);

			if (temp != null)
				return Ok(temp);
			else
				return BadRequest(temp);			
        }
        
        // POST: api/Crew
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InputCrewDTO crew)
        {
			if (ModelState.IsValid)
			{				
				await crewService.CreateCrew(crew);
				return Ok(crew);
			}
			else
			{
				return BadRequest(crew);
			}		
        }
        
        // PUT: api/Crew/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]InputCrewDTO crew)
        {
			if (ModelState.IsValid)
			{
				//Response.StatusCode = 200;
				await crewService.UpdateCrew(id, crew);
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
			await crewService.DeleteCrewById(id);
        }


		[Route("/api/crew/special")]
		public async Task Special()
		{
			await crewService.SpecialFunction();
		}
    }
}
