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
    public class TicketRepository : ITicketRepository
    {
		private List<Ticket> tickets = new List<Ticket>();
		MyContext db;

		public TicketRepository(MyContext db)
		{
			this.db = db;
			//using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\tickets.json"))
			//{
		//		JsonSerializer serializer = new JsonSerializer();
		//		tickets = (List<Ticket>)serializer.Deserialize(file, typeof(List<Ticket>));
		//	}
		}

		public void SaveChanges()
		{
		//	File.WriteAllText(Environment.CurrentDirectory + @"\Data\tickets.json",
		//		JsonConvert.SerializeObject(tickets));
		}

		public async Task<List<Ticket>> GetAll()
		{			
			return await db.Ticket.ToListAsync();
		}

		public async Task<Ticket> Get(int id)
		{
			return await db.Ticket.FindAsync(id);
		}

		public async Task Delete(int id)
		{
			Ticket temp = await db.Ticket.FindAsync(id);
			if (temp != null)
			{
				db.Ticket.Remove(temp);
				await db.SaveChangesAsync();
			}				
		}

		public async Task Create(Ticket item)
		{
			await db.Ticket.AddAsync(item);
			await db.SaveChangesAsync();
		}

		public async Task Update(int id, Ticket item)
		{
			Ticket temp = await db.Ticket.FindAsync(id);
			if (temp != null)
			{
				temp.Price = item.Price;

				db.Ticket.Update(temp);
				await db.SaveChangesAsync();				
			}
		}
	}
}
