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
    [Route("api/Stewardess")]
    public class StewardessController : Controller
    {
		private IStewardessService stewardessService;

		public StewardessController(IStewardessService stewardessService)
		{
			this.stewardessService = stewardessService; 
		}

        // GET: api/Stewardess
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<StewardessDTO> temp = await stewardessService.GetStewardessCollection();

			if (temp != null)
				return Ok(temp);
			else
				return BadRequest();

		}

        // GET: api/Stewardess/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
			StewardessDTO temp = await stewardessService.GetStewardessById(id);

			if (temp != null)
				return Ok(temp);
			else
				return BadRequest();
			
		}
        
        // POST: api/Stewardess
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StewardessDTO stewardess)
        {
			if (ModelState.IsValid)
			{				
				await stewardessService.CreateStewardess(stewardess);
				return Ok();
			}
			else
			{
				return BadRequest();
			}		
        }
        
        // PUT: api/Stewardess/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]StewardessDTO stewardess)
		{
			if (ModelState.IsValid)
			{				
				await stewardessService.UpdateStewardess(id, stewardess);
				return Ok(stewardess);
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
			await stewardessService.DeleteStewardessById(id);
        }
    }
}
