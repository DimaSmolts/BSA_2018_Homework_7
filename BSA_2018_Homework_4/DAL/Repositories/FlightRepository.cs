using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using Newtonsoft.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;


namespace BSA_2018_Homework_4.DAL.Repositories
{
    public class FlightRepository : IFlightRepository
    {
		private List<Flight> flights = new List<Flight>();
		MyContext db;

		public FlightRepository(MyContext db)
		{
			this.db = db;
		//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\flights.json"))
		//	{
			//	JsonSerializer serializer = new JsonSerializer();
			//	flights = (List<Flight>)serializer.Deserialize(file, typeof(List<Flight>));
			//}
		}

		public void SaveChanges()
		{
			//File.WriteAllText(Environment.CurrentDirectory + @"\Data\flights.json",
			//	JsonConvert.SerializeObject(flights));
		}

		public async Task<List<Flight>> GetAll()
		{
			//List<Flight> test = db.Flight.ToList();

			return await  db.Flight.ToListAsync();
		}

		public async Task<Flight> Get(int id)
		{
			return await db.Flight.FindAsync(id);
		}

		public async Task Delete(int id)
		{
			Flight temp = await db.Flight.FindAsync(id);
			if (temp != null)
			{
				db.Flight.Remove(temp);
				await db.SaveChangesAsync();
			}				
		}

		public async Task Create(Flight item)
		{
			await db.Flight.AddAsync(item);
			await db.SaveChangesAsync();
		}

		public async Task Update(int id,Flight item)
		{
			Flight temp = await db.Flight.FindAsync(id);
			if (temp != null)
			{
				//temp.FlightId = item.FlightNum;
				temp.DeperturePlace = item.DeperturePlace;
				temp.DepartureTime = item.DepartureTime;
				temp.ArrivalPlace = item.ArrivalPlace;
				temp.ArrivalTime = item.ArrivalTime;
				//temp.TicketId = item.TicketId;

				db.Flight.Update(temp);
				await db.SaveChangesAsync();
			}

			//Flight temp = db.Flight.Find(id);
			//if (temp != null)
			//{
			//	db.Flight.Remove(temp);
			//	db.Flight.Add(item);
			//}
		}
	}
}
