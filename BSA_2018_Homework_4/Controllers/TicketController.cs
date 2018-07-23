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
    [Route("api/Ticket")]
    public class TicketController : Controller
    {
		private ITicketService ticketService;

		public TicketController(ITicketService ticketService)
		{
			this.ticketService = ticketService;
		}

        // GET: api/Ticket
        [HttpGet]
        public async Task<IActionResult> Get()
        {
			List<TicketDTO> temp = await ticketService.GetTicketCollection();

			if (temp != null)
				return Ok(temp);
			else
				return BadRequest();
		}

        // GET: api/Ticket/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TicketDTO temp = await ticketService.GetTicketById(id);

			if (temp != null)
				return Ok(temp);
			else
				return BadRequest();
		}
        
        // POST: api/Ticket
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InputTicketDTO ticket)
        {
			if (ModelState.IsValid)
			{				
				await ticketService.CreateTicket(ticket);
				return Ok(ticket);
			}
			else
			{
				return BadRequest();
			}			
        }
        
        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]InputTicketDTO ticket)
        {
			if (ModelState.IsValid)
			{
				await ticketService.UpdateTicket(id, ticket);
				return Ok(ticket);
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
			await ticketService.DeleteTicketById(id);
        }
    }
}
