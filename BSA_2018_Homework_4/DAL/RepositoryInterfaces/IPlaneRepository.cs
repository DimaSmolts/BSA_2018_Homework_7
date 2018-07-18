using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
    public interface IPlaneRepository
    {
		Task<List<Plane>> GetAll();
		Task<Plane> Get(int id);
		Task Delete(int id);
		Task Create(Plane item);
		Task Update(int id, Plane item);
	}
}
