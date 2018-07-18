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
    public class TakeOffService : ITakeOffService
    {
		private DAL.IUnitOfWork IunitOfWork;

		public TakeOffService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public async Task CreateTakeOff(TakeOffDTO item)
		{
			//TakeOff temp = Mapper.Map<TakeOffDTO, TakeOff>(item);
			//temp.CrewId = IunitOfWork.CrewRepository.Get(item.CrewId);

			//temp.FlightNum = IunitOfWork.FlightRepository.Get(item.FlightNum);

			//temp.PlaneId = IunitOfWork.PlaneRepository.Get(item.PlaneId);

			//if(temp.CrewId != null && temp.PlaneId != null && temp.FlightNum != null)
			//{
			//	IunitOfWork.TakeOffRepository.Create(temp);
			//}		


			await IunitOfWork.TakeOffRepository.Create(Mapper.Map<TakeOffDTO, TakeOff>(item));

		}

		public async Task DeleteTakeOffById(int id)
		{
			await IunitOfWork.TakeOffRepository.Delete(id);
		}

		public async Task<TakeOffDTO> GetTakeOffById(int id)
		{
			//List<TakeOff> temp = IunitOfWork.TakeOffRepository.GetAll();

			//List<TakeOffDTO> tempDTO = 


			return Mapper.Map<TakeOff, TakeOffDTO>(await IunitOfWork.TakeOffRepository.Get(id));
		}

		public async Task<List<TakeOffDTO>> GetTakeOffCollection()
		{
			//List<TakeOff> temp = IunitOfWork.TakeOffRepository.GetAll();

			//List<TakeOffDTO> tempDTO = 


			return Mapper.Map<List<TakeOff>, List<TakeOffDTO>>(await IunitOfWork.TakeOffRepository.GetAll());
		}

		public async Task UpdateTakeOff(int id, TakeOffDTO item)
		{
			await IunitOfWork.TakeOffRepository.Update(id, Mapper.Map<TakeOffDTO, TakeOff>(item));
		}
	}
}
