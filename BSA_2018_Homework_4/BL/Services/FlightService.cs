using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using BSA_2018_Homework_4.DTOs;
using BSA_2018_Homework_4.DAL.Models;
using AutoMapper;

namespace BSA_2018_Homework_4.BL.Services
{
    public class FlightService : IFlightService
    {
		//private IFlightRepository flightRepository;

		private DAL.IUnitOfWork IunitOfWork;

		public FlightService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public async Task CreateFlight(FlightDTO item)
		{
			await IunitOfWork.FlightRepository.Create(Mapper.Map<FlightDTO, Flight>(item));
		}

		public async Task DeleteFlightById(int id)
		{
			await IunitOfWork.FlightRepository.Delete(id);
		}

		public async Task< FlightDTO> GetFlightById(int id)
		{
			return Mapper.Map<Flight, FlightDTO>(await IunitOfWork.FlightRepository.Get(id)); 
		}

		public async Task<List<FlightDTO>> GetFlightCollection()
		{
			return Mapper.Map<List<Flight>, List<FlightDTO>>(await IunitOfWork.FlightRepository.GetAll());
		}

		public async Task UpdateFlight(int id, FlightDTO item)
		{
			await IunitOfWork.FlightRepository.Update(id,Mapper.Map<FlightDTO, Flight>(item));
		}
	}
}
