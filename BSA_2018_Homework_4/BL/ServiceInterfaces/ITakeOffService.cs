using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;
using BSA_2018_Homework_4.DTOs.InputDTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface ITakeOffService
    {
		Task<List<TakeOffDTO>> GetTakeOffCollection();
		Task<TakeOffDTO> GetTakeOffById(int id);
		Task DeleteTakeOffById(int id);
		Task CreateTakeOff(InputTakeOffDTO item);
		Task UpdateTakeOff(int id, InputTakeOffDTO item);
	}
}
