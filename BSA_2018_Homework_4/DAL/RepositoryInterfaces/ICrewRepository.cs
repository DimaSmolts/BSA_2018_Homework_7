using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
	public interface ICrewRepository
    {
		Task<List<Crew>> GetAll();
		Task<Crew> Get(int id);
		Task Delete(int id);
		Task Create(Crew item);
		Task Update(int id, Crew item);
	}
}
