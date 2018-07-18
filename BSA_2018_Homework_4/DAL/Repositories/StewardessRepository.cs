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
    public class StewardessRepository : IStewardessRepository
    {
		private List<Stewardess> stewardesses = new List<Stewardess>();
		MyContext db;

		public StewardessRepository(MyContext db)
		{
			this.db = db;
		//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\stewardesses.json"))
		//	{
		//		JsonSerializer serializer = new JsonSerializer();
		//		stewardesses = (List<Stewardess>)serializer.Deserialize(file, typeof(List<Stewardess>));
		//	}
		}

		public void SaveChanges()
		{
			//File.WriteAllText(Environment.CurrentDirectory + @"\Data\stewardesses.json",
			//	JsonConvert.SerializeObject(stewardesses));
		}

		public async Task<List<Stewardess>> GetAll()
		{
			return await db.Stewardess.ToListAsync();
		}

		public async Task<Stewardess> Get(int id)
		{
			return await db.Stewardess.FindAsync(id);
		}

		public async Task Delete(int id)
		{
			Stewardess temp = await db.Stewardess.FindAsync(id);
			if (temp != null)
			{
				db.Stewardess.Remove(temp);
				await db.SaveChangesAsync();
			}				
		}

		public async Task Create(Stewardess item)
		{
			await db.Stewardess.AddAsync(item);
			await db.SaveChangesAsync();
		}

		public async Task Update(int id, Stewardess item)
		{
			Stewardess temp = await db.Stewardess.FindAsync(id);
			if (temp != null)
			{

				temp.Name = item.Name;
				temp.Surname = item.Surname;
				temp.Birth = item.Birth;

				db.Stewardess.Update(temp);
				await db.SaveChangesAsync();
			}
		}
	}
}
