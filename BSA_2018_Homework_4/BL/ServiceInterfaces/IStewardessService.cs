using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface IStewardessService
    {
		Task<List<StewardessDTO>> GetStewardessCollection();
		Task<StewardessDTO> GetStewardessById(int id);
		Task DeleteStewardessById(int id);
		Task CreateStewardess(StewardessDTO item);
		Task UpdateStewardess(int id, StewardessDTO item);
	}
}
