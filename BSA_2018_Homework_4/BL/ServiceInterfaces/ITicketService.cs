using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface ITicketService
    {
		Task<List<TicketDTO>> GetTicketCollection();
		Task<TicketDTO> GetTicketById(int id);
		Task DeleteTicketById(int id);
		Task CreateTicket(TicketDTO item);
		Task UpdateTicket(int id, TicketDTO item);
	}
}
