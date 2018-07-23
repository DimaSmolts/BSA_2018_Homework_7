using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using BSA_2018_Homework_4.DTOs;
using BSA_2018_Homework_4.DTOs.InputDTOs;
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

		public async Task CreateTakeOff(InputTakeOffDTO item)
		{
			TakeOff temp = Mapper.Map<InputTakeOffDTO, TakeOff>(item);
			temp.CrewId = await IunitOfWork.CrewRepository.Get(item.CrewId);

			temp.FlightNum = await IunitOfWork.FlightRepository.Get(item.FlightNum);

			temp.PlaneId = await IunitOfWork.PlaneRepository.Get(item.PlaneId);

			if (temp.CrewId != null && temp.PlaneId != null && temp.FlightNum != null)
			{
				await IunitOfWork.TakeOffRepository.Create(temp);
			}
			else
			{
				throw new Exception();
			}


			//await IunitOfWork.TakeOffRepository.Create(Mapper.Map<InputTakeOffDTO, TakeOff>(item));

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

		public async Task UpdateTakeOff(int id, InputTakeOffDTO item)
		{
			TakeOff temp = Mapper.Map<InputTakeOffDTO, TakeOff>(item);
			temp.CrewId = await IunitOfWork.CrewRepository.Get(item.CrewId);

			temp.FlightNum = await IunitOfWork.FlightRepository.Get(item.FlightNum);

			temp.PlaneId = await IunitOfWork.PlaneRepository.Get(item.PlaneId);

			if (temp.CrewId != null && temp.PlaneId != null && temp.FlightNum != null)
			{
				await IunitOfWork.TakeOffRepository.Update(id, temp);
			}
			else
			{
				throw new Exception();
			}
		}
	}
}
