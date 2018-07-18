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
    public class CrewRepository : ICrewRepository
    {
		private List<Crew> crews = new List<Crew>();
		MyContext db;

		public CrewRepository(MyContext db)
		{
			this.db = db;
			//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\crews.json"))
			//{
			//	JsonSerializer serializer = new JsonSerializer();
			//	crews = (List<Crew>)serializer.Deserialize(file, typeof(List<Crew>));
			//}
		}

		public void SaveChanges()
		{
		//	File.WriteAllText(Environment.CurrentDirectory + @"\Data\crews.json",
			//	JsonConvert.SerializeObject(crews));
		}

		public async Task<List<Crew>> GetAll()
		{
			return await db.Crew
				.Include(t => t.StewardessIds)
				.Include(t => t.PilotId)
				.ToListAsync();
				
		}

		public async Task<Crew> Get(int id)
		{
			return await db.Crew
				.Include(t => t.PilotId)
				.Include( t => t.StewardessIds)
				.FirstOrDefaultAsync(t =>t.Id == id)
				//.Include(t => t.StewardessIds)
				//.Include(t => t.PilotId)
				;
		}

		public async Task Delete(int id)
		{
			Crew temp = await db.Crew.FindAsync(id);
			if (temp != null)
			{
				db.Crew.Remove(temp);
				await db.SaveChangesAsync();
			}				
		}

		public async Task Create(Crew item)
		{
			await db.Crew.AddAsync(item);
			await db.SaveChangesAsync();
		}

		public async Task Update(int id, Crew item)
		{
			//Crew temp = crews.FirstOrDefault(t => t.Id == id);
			//if (temp != null)
			//{

			//}

			Crew temp = await db.Crew.FindAsync(id);
			if (temp != null)
			{
					temp.Id = item.Id;
					temp.PilotId = item.PilotId;
					temp.StewardessIds = item.StewardessIds;

				db.Crew.Update(temp);
				await db.SaveChangesAsync();
			}
		}
	}
}
