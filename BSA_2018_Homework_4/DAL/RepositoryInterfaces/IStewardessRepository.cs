using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
	public interface IStewardessRepository
    {
		Task<List<Stewardess>> GetAll();
		Task<Stewardess> Get(int id);
		Task Delete(int id);
		Task Create(Stewardess item);
		Task Update(int id, Stewardess item);
	}
}
