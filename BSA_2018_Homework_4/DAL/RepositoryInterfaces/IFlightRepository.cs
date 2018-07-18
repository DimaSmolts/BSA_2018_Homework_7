using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
    public interface IFlightRepository
    {
		Task<List<Flight>> GetAll();
		Task<Flight> Get(int id);
		Task Delete(int id);
		Task Create(Flight item);
		Task Update(int id, Flight item);
	}
}
