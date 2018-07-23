using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSA_2018_Homework_4.DTOs.InputDTOs
{
    public class InputPlaneDTO
    {
		public string Name { get; set; }
		public int Type { get; set; }
		public DateTime Made { get; set; }
		public TimeSpan Exploitation { get; set; }
	}
}
