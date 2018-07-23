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
    [Route("api/TakeOff")]
    public class TakeOffController : Controller
    {
		private ITakeOffService takeOffService;

		public TakeOffController(ITakeOffService takeOffService)
		{
			this.takeOffService = takeOffService;
		}

        // GET: api/TakeOff
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TakeOffDTO> temp = await takeOffService.GetTakeOffCollection();

			if (temp != null)
				return Ok(temp);
			else
				return NotFound(temp);
		}

        // GET: api/TakeOff/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TakeOffDTO temp = await takeOffService.GetTakeOffById(id);

			if (temp != null)
				return Ok(temp);
			else
				return NotFound(temp);
		}
        
        // POST: api/TakeOff
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InputTakeOffDTO takeOff)
        {
			if (ModelState.IsValid)
			{
				//Response.StatusCode = 200;
				await takeOffService.CreateTakeOff(takeOff);
				return Ok(takeOff);
			}
			else
			{
				return BadRequest();
			}			
        }
        
        // PUT: api/TakeOff/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]InputTakeOffDTO takeOff)
        {
			if (ModelState.IsValid)
			{
				//Response.StatusCode = 200;
				await takeOffService.UpdateTakeOff(id, takeOff);
				return Ok(takeOff);
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
			await takeOffService.DeleteTakeOffById(id);
        }
    }
}
