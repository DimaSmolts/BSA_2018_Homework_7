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
    [Route("api/PlaneType")]
    public class PlaneTypeController : Controller
    {
		private IPlaneTypeService planeTypeService;

		public PlaneTypeController(IPlaneTypeService planeTypeService)
		{
			this.planeTypeService = planeTypeService;
		}

        // GET: api/PlaneType
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<PlaneTypeDTO> temp = await planeTypeService.GetPlaneTypeCollection();

			if (temp != null)
				return Ok(temp);
			else
				return NotFound(temp);
		}

        // GET: api/PlaneType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PlaneTypeDTO temp = await planeTypeService.GetPlaneTypeById(id);

			if (temp != null)
				return Ok(temp);
			else
				return NotFound(temp);
		}
        
        // POST: api/PlaneType
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PlaneTypeDTO planeType)
        {
			if (ModelState.IsValid)
			{
				//Response.StatusCode = 200;
				await planeTypeService.CreatePlaneType(planeType);
				return Ok(planeType);
			}
			else
			{
				return BadRequest();
			}			
        }
        
        // PUT: api/PlaneType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PlaneTypeDTO planeType)
        {
			if (ModelState.IsValid)
			{
				//Response.StatusCode = 200;
				await planeTypeService.UpdatePlaneType(id,planeType);
				return Ok(planeType);
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
			await planeTypeService.DeletePlaneType(id);
        }
    }
}
