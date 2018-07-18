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
    public class StewardessService : IStewardessService
    {
		private DAL.IUnitOfWork IunitOfWork;

		public StewardessService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public async Task CreateStewardess(StewardessDTO item)
		{
			await IunitOfWork.StewardessRepository.Create(Mapper.Map<StewardessDTO, Stewardess>(item));
		}

		public async Task DeleteStewardessById(int id)
		{
			await IunitOfWork.StewardessRepository.Delete(id);
		}

		public async Task<StewardessDTO> GetStewardessById(int id)
		{
			return Mapper.Map<Stewardess,StewardessDTO>(await IunitOfWork.StewardessRepository.Get(id));
		}

		public async Task<List<StewardessDTO>> GetStewardessCollection()
		{
			return Mapper.Map<List<Stewardess>,List<StewardessDTO>>(await IunitOfWork.StewardessRepository.GetAll());
		}

		public async Task UpdateStewardess(int id, StewardessDTO item)
		{
			await IunitOfWork.StewardessRepository.Update(id,Mapper.Map<StewardessDTO,Stewardess>(item));
		}
	}
}
