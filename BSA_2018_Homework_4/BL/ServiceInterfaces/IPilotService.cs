using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface IPilotService
    {
		Task<List<PilotDTO>> GetPilotCollection();
		Task<PilotDTO> GetPilotById(int id);
		Task DeletePilotById(int id);
		Task CreatePilot(PilotDTO item);
		Task UpdatePilot(int id, PilotDTO item);
	}
}
