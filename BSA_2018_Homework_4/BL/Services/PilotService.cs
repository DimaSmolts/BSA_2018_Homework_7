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
    public class PilotService : IPilotService
    {
		//private IPilotRepository pilotRepo;
		private DAL.IUnitOfWork IunitOfWork;

		public PilotService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public async Task CreatePilot(PilotDTO item)
		{
			await IunitOfWork.PilotRepository.Create(Mapper.Map<PilotDTO, Pilot>(item));
		}

		public async Task DeletePilotById(int id)
		{
			await IunitOfWork.PilotRepository.Delete(id);
		}

		public async Task<PilotDTO> GetPilotById(int id)
		{
			return Mapper.Map<Pilot,PilotDTO>(await IunitOfWork.PilotRepository.Get(id));
		}

		public async Task<List<PilotDTO>> GetPilotCollection()
		{


			return Mapper.Map<List<Pilot>, List<PilotDTO>>(await IunitOfWork.PilotRepository.GetAll());
		}

		public async Task UpdatePilot(int id, PilotDTO item)
		{
			await IunitOfWork.PilotRepository.Update(id, Mapper.Map<PilotDTO, Pilot>(item));
		}
	}
}
