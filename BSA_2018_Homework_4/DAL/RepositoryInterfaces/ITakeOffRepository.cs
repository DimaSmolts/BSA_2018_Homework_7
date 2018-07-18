using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL.RepositoryInterfaces
{
	public interface ITakeOffRepository
    {
		Task<List<TakeOff>> GetAll();
		Task<TakeOff> Get(int id);
		Task Delete(int id);
		Task Create(TakeOff item);
		Task Update(int id, TakeOff item);
	}
}
