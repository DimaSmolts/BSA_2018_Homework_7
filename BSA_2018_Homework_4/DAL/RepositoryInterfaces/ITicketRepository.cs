using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
	public interface ITicketRepository
    {
		Task<List<Ticket>> GetAll();
		Task<Ticket> Get(int id);
		Task Delete(int id);
		Task Create(Ticket item);
		Task Update(int id, Ticket item);
	}
}
