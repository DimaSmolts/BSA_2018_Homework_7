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
    public class PlaneTypeRepository : IPlaneTypeRepository
    {
		private List<PlaneType> planetypes = new List<PlaneType>();
		MyContext db;

		public PlaneTypeRepository(MyContext db)
		{
			this.db = db;

		//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\planetypes.json"))
			//{
		//		JsonSerializer serializer = new JsonSerializer();
		//		planetypes = (List<PlaneType>)serializer.Deserialize(file, typeof(List<PlaneType>));
		//	}
		}

		public void SaveChanges()
		{
		//	File.WriteAllText(Environment.CurrentDirectory + @"\Data\planetypes.json",
			//	JsonConvert.SerializeObject(planetypes));
		}

		public async Task<List<PlaneType>> GetAll()
		{
			return await db.PlaneType.ToListAsync();
		}

		public async Task<PlaneType> Get(int id)
		{
			return await  db.PlaneType.FindAsync(id);
		}

		public async Task Delete(int id)
		{
			PlaneType temp = await db.PlaneType.FindAsync(id);
			if (temp != null)
			{
				db.PlaneType.Remove(temp);
				await db.SaveChangesAsync();
			}				
		}

		public async Task Create(PlaneType item)
		{
			await db.PlaneType.AddAsync(item);
			await db.SaveChangesAsync();
		}

		public async Task Update(int id, PlaneType item)
		{			

			PlaneType temp = await db.PlaneType.FindAsync(id);
			if (temp != null)
			{
				temp.CarryCapacity = item.CarryCapacity;
				temp.Model = item.Model;
				temp.Places = item.Places;


				db.PlaneType.Update(temp);
				await db.SaveChangesAsync();
			}

		}
	}
}
