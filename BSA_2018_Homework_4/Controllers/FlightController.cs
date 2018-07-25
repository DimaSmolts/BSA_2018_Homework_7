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
	[Route("api/Flight")]
	public class FlightController : Controller
    {
		private IFlightService flightService;

		public FlightController(IFlightService flightService)
		{
			this.flightService = flightService;
		}

		// GET: api/Flight
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			 List<FlightDTO> temp = await flightService.GetFlightCollection();

			if (temp != null)
				return Ok(temp);
			else
				return NotFound(temp);

			//return temp;
		}

		// GET: api/Flight/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			FlightDTO temp = await flightService.GetFlightById(id);

			if (temp != null)
				return Ok(temp);
			else
				return NotFound(temp);
			
		}

		// POST: api/Flight
		[HttpPost]
		public async Task<IActionResult> Post([FromBody]FlightDTO flight)
		{
			if (ModelState.IsValid)
			{
				//Response.StatusCode = 200;
				await flightService.CreateFlight(flight);
				return Ok(flight);
			}
			else
			{
				return BadRequest();
			}			
		}

		// PUT: api/Flight/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody]FlightDTO flight)
		{
			if (ModelState.IsValid)
			{
				//Response.StatusCode = 200;
				await flightService.UpdateFlight(id,flight);
				return Ok(flight);
			}
			else
			{
				return BadRequest();
			}
		}

		// DELETE: api/Flight/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await flightService.DeleteFlightById(id);
		}
	}
}