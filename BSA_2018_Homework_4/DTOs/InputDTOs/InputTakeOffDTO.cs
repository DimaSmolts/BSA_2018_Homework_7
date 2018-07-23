using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSA_2018_Homework_4.DTOs.InputDTOs
{
    public class InputTakeOffDTO
    {		
		public int FlightNum { get; set; }
		public DateTime Date { get; set; }
		public int CrewId { get; set; }
		public int PlaneId { get; set; }
	}
}
