using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;
using BSA_2018_Homework_4.DTOs.InputDTOs;
using BSA_2018_Homework_4.DTOs.DTOsForRemote;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface ICrewService
    {
		Task<List<CrewDTO>> GetCrewCollection();
		Task<CrewDTO> GetCrewById(int id);
		Task DeleteCrewById(int id);
		Task CreateCrew(InputCrewDTO item);
		Task UpdateCrew(int id, InputCrewDTO item);

		Task SpecialFunction();
	}
}
