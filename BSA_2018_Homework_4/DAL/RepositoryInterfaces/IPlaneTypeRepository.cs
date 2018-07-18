using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
	public interface IPlaneTypeRepository
    {
		Task<List<PlaneType>> GetAll();
		Task<PlaneType> Get(int id);
		Task Delete(int id);
		Task Create(PlaneType item);
		Task Update(int id, PlaneType item);
	}
}
