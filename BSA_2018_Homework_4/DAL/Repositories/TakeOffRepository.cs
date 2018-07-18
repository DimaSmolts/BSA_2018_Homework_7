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
    public class TakeOffRepository : ITakeOffRepository
    {
		private List<TakeOff> takeoffs = new List<TakeOff>();
		MyContext db;

		public TakeOffRepository(MyContext db)
		{
			this.db = db;
		//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\takeoffs.json"))
			//{
		//		JsonSerializer serializer = new JsonSerializer();
		//		takeoffs = (List<TakeOff>)serializer.Deserialize(file, typeof(List<TakeOff>));
		//	}
		}

		public void SaveChanges()
		{
			//File.WriteAllText(Environment.CurrentDirectory + @"\Data\takeoffs.json",
			//	JsonConvert.SerializeObject(takeoffs));
		}

		public async Task<List<TakeOff>> GetAll()
		{
			//	List<TakeOff> temp = db.TakeOff.ToList();

			return await db.TakeOff
				.Include(t => t.PlaneId)
				.ThenInclude(p => p.Type)
				.Include(t => t.FlightNum)
				.Include(t => t.CrewId)
				.ThenInclude(c => c.PilotId)
				.Include(t => t.CrewId)
				.ThenInclude(c => c.StewardessIds)
				.ToListAsync();
		}

		public async Task< TakeOff> Get(int id)
		{
			return await db.TakeOff
				.Include(t => t.PlaneId)
				.ThenInclude(p => p.Type)
				.Include(t => t.FlightNum)
				.Include(t => t.CrewId)
				.ThenInclude(c => c.PilotId)
				.Include(t => t.CrewId)
				.ThenInclude(c => c.StewardessIds)
				.FirstOrDefaultAsync(t => t.Id == id);
		}

		public async Task Delete(int id)
		{
			TakeOff temp = await db.TakeOff.FindAsync(id);
			if (temp != null)
			{
				db.TakeOff.Remove(temp);
				await db.SaveChangesAsync();
			}				
		}

		public async Task Create(TakeOff item)
		{
			await db.AddAsync(item);
			await db.SaveChangesAsync();
		}

		public async Task Update(int id, TakeOff item)
		{
			TakeOff temp = await db.TakeOff.FindAsync(id);
			if (temp != null)
			{
				//temp.Id = item.Id;
				temp.FlightNum = item.FlightNum;
				temp.Date = item.Date;
				temp.CrewId = item.CrewId;
				temp.PlaneId = item.PlaneId;

				db.TakeOff.Update(temp);
				await db.SaveChangesAsync();
			}

			//TakeOff temp = db.TakeOff.Find(id);
			//if (temp != null)
			//{
			//	db.TakeOff.Remove(temp);
			//	db.TakeOff.Add(item);
			//}

		}
	}
}
