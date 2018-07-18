using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface IFlightService
    {
		Task<List<FlightDTO>> GetFlightCollection();
		Task<FlightDTO> GetFlightById(int id);
		Task DeleteFlightById(int id);
		Task CreateFlight(FlightDTO item);
		Task UpdateFlight(int id, FlightDTO item);
	}
}
