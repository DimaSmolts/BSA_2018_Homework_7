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
    public class PlaneService : IPlaneService
    {
		//private IPlaneRepository planeRepo;

		private DAL.IUnitOfWork IunitOfWork;

		public PlaneService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public async Task<List<PlaneDTO>> GetPlaneCollection()
		{
			//List<Plane> temp = IunitOfWork.PlaneRepository.GetAll();
			//List<PlaneDTO> selected = Mapper.Map<List<Plane>, List<PlaneDTO>>(temp);

			//foreach(PlaneDTO p in selected)
			//{
			//	p.Type = (from x in temp
			//			  where x.Id == p.Id
			//			  select x.Type.Id).First();
			//}

			//return selected;

			return Mapper.Map<List<Plane>, List<PlaneDTO>>(await IunitOfWork.PlaneRepository.GetAll());

		}
		public async Task<PlaneDTO> GetPlaneById(int id)
		{
			//Plane temp = IunitOfWork.PlaneRepository.Get(id);
			//PlaneDTO selected = Mapper.Map<Plane, PlaneDTO>(temp);

			//if(temp != null)
			//{
			//	selected.Type = temp.Type.Id;
			//	return selected;
			//}
			//else
			//{
			//	throw new Exception();
			//}
			return Mapper.Map<Plane, PlaneDTO>(await IunitOfWork.PlaneRepository.Get(id));
		}
		public async Task DeletePlaneById(int id)
		{
			await IunitOfWork.PlaneRepository.Delete(id);
		}
		public async Task CreatePlane(InputPlaneDTO item)
		{
			Plane temp = Mapper.Map<InputPlaneDTO, Plane>(item);
			temp.Type = await IunitOfWork.PlaneTypeRepository.Get(item.Type);
			if (temp.Type != null)
			{
				await IunitOfWork.PlaneRepository.Create(temp);
			}
			else
			{
				throw new Exception();
			}

			//await IunitOfWork.PlaneRepository.Create(Mapper.Map<PlaneDTO, Plane>(item));

		}
		public async Task UpdatePlane(int id, InputPlaneDTO item)
		{
			Plane temp = Mapper.Map<InputPlaneDTO, Plane>(item);
			temp.Type = await IunitOfWork.PlaneTypeRepository.Get(item.Type);
			if (temp.Type != null)
			{
				await IunitOfWork.PlaneRepository.Update(id, temp);
			}
			else
			{
				throw new Exception();
			}		
		}

	}
}
