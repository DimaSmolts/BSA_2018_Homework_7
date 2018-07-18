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
    [Route("api/Plane")]
    public class PlaneController : Controller
    {
		private IPlaneService planeService;

		public PlaneController(IPlaneService planeService)
		{
			this.planeService = planeService;
		}

        // GET: api/Plane
        [HttpGet]
        public async Task<IActionResult> Get()
        {
			List<PlaneDTO> temp = await planeService.GetPlaneCollection();

			if (temp != null)
				return Ok(temp);
			else
				return BadRequest();
		}

        // GET: api/Plane/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
			PlaneDTO temp = await planeService.GetPlaneById(id);

			if (temp != null)
				return Ok(temp);
			else
				return BadRequest();
		}
        
        // POST: api/Plane
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PlaneDTO plane)
        {
			if (ModelState.IsValid)
			{
				//Response.StatusCode = 200;
				await planeService.CreatePlane(plane);
				return Ok(plane);
			}
			else
			{
				return BadRequest();
			}			
        }
        
        // PUT: api/Plane/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PlaneDTO plane)
        {
			if (ModelState.IsValid)
			{
				//Response.StatusCode = 200;
				await planeService.UpdatePlane(id, plane);
				return Ok(plane);
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
			await planeService.DeletePlaneById(id);
        }
    }
}
