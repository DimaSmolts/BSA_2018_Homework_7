using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
	public interface IPilotRepository
    {
		Task<List<Pilot>> GetAll();
		Task<Pilot> Get(int id);
		Task Delete(int id);
		Task Create(Pilot item);
		Task Update(int id, Pilot item);
	}
}
