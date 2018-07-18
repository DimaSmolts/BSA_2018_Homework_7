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
    public class PilotRepository : IPilotRepository
    {
		private List<Pilot> pilots = new List<Pilot>();
		MyContext db;

		public PilotRepository(MyContext db)
		{
			this.db = db;
			//using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\pilots.json"))
			//{
			//	JsonSerializer serializer = new JsonSerializer();
			//	pilots = (List<Pilot>)serializer.Deserialize(file, typeof(List<Pilot>));
			//}
		}

		public void SaveChanges()
		{
			//File.WriteAllText(Environment.CurrentDirectory + @"\Data\pilots.json",
			//	JsonConvert.SerializeObject(pilots));
		}

		public async Task<List<Pilot>> GetAll()
		{
			return await db.Pilot.ToListAsync();
		}

		public async Task<Pilot> Get(int id)
		{
			return await db.Pilot.FindAsync(id);
		}

		public async Task Delete(int id)
		{
			Pilot temp = await db.Pilot.FindAsync(id);
			if (temp != null)
			{
				db.Pilot.Remove(temp);
				await db.SaveChangesAsync();
			}				
		}

		public async Task Create(Pilot item)
		{
			await db.Pilot.AddAsync(item);
			await db.SaveChangesAsync();
			//return item;
		}

		public async Task Update(int id, Pilot item)
		{
			Pilot temp = await db.Pilot.FindAsync(id);
			if (temp != null)
			{
				//temp.Id = item.Id;
				temp.Name = item.Name;
				temp.Surname = item.Surname;
				temp.Birth = item.Birth;
				temp.Experience = item.Experience;

				db.Pilot.Update(temp);
				await db.SaveChangesAsync();
			}
		}
	}
}
