using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface ICrewService
    {
		Task<List<CrewDTO>> GetCrewCollection();
		Task<CrewDTO> GetCrewById(int id);
		Task DeleteCrewById(int id);
		Task CreateCrew(CrewDTO item);
		Task UpdateCrew(int id, CrewDTO item);
	}
}
