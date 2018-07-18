using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface ITakeOffService
    {
		Task<List<TakeOffDTO>> GetTakeOffCollection();
		Task<TakeOffDTO> GetTakeOffById(int id);
		Task DeleteTakeOffById(int id);
		Task CreateTakeOff(TakeOffDTO item);
		Task UpdateTakeOff(int id, TakeOffDTO item);
	}
}
