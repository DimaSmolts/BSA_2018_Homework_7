using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface IPlaneTypeService
    {
		Task<List<PlaneTypeDTO>> GetPlaneTypeCollection();
		Task<PlaneTypeDTO> GetPlaneTypeById(int id);
		Task DeletePlaneType(int id);
		Task CreatePlaneType(PlaneTypeDTO item);
		Task UpdatePlaneType(int id, PlaneTypeDTO item);
	}
}
