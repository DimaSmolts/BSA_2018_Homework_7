using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.BL.ServiceInterfaces
{
    public interface IPlaneService
    {
		Task<List<PlaneDTO>> GetPlaneCollection();
		Task<PlaneDTO> GetPlaneById(int id);
		Task DeletePlaneById(int id);
		Task CreatePlane(PlaneDTO item);
		Task UpdatePlane(int id, PlaneDTO item);
	}
}
