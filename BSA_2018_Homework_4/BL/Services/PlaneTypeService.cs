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
    public class PlaneTypeService : IPlaneTypeService
    {
		private DAL.IUnitOfWork IunitOfWork;

		public PlaneTypeService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public async Task CreatePlaneType(PlaneTypeDTO item)
		{
			await IunitOfWork.PlaneTypeRepository.Create(Mapper.Map<PlaneTypeDTO,PlaneType>(item));
		}

		public async Task DeletePlaneType(int id)
		{
			await IunitOfWork.PlaneTypeRepository.Delete(id);
		}

		public async Task<PlaneTypeDTO> GetPlaneTypeById(int id)
		{
			return Mapper.Map<PlaneType,PlaneTypeDTO>(await IunitOfWork.PlaneTypeRepository.Get(id));
		}

		public async Task<List<PlaneTypeDTO>> GetPlaneTypeCollection()
		{
			return Mapper.Map<List<PlaneType>, List<PlaneTypeDTO>>(await IunitOfWork.PlaneTypeRepository.GetAll());
		}

		public async Task UpdatePlaneType(int id, PlaneTypeDTO item)
		{
			await IunitOfWork.PlaneTypeRepository.Update(id, Mapper.Map<PlaneTypeDTO, PlaneType>(item));
		}
	}
}
