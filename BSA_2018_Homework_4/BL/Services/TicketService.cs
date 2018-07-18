﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using BSA_2018_Homework_4.DTOs;
using BSA_2018_Homework_4.DAL.Models;
using AutoMapper;

namespace BSA_2018_Homework_4.BL.Services
{
    public class TicketService : ITicketService
    {
		private DAL.IUnitOfWork IunitOfWork;

		public TicketService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public async Task<List<TicketDTO>> GetTicketCollection()
		{
			//List<Ticket> temp = IunitOfWork.TicketRepository.GetAll();
			//List<TicketDTO> selected = Mapper.Map<List<Ticket>, List<TicketDTO>>(temp);


			//foreach (TicketDTO t in selected)
			//{
			//	t.FlightNum = (from x in temp
			//		   where x.Id == t.Id
			//		   select x.FlightNum.FlightId).First();
			//}
			//return selected;

			return Mapper.Map<List<Ticket>, List<TicketDTO>>(await IunitOfWork.TicketRepository.GetAll());

		}
		public async Task<TicketDTO> GetTicketById(int id)
		{
			//Ticket temp = IunitOfWork.TicketRepository.Get(id);
			//TicketDTO selected = Mapper.Map<Ticket, TicketDTO>(temp);

			//if(temp != null)
			//{
			//	selected.FlightNum = temp.FlightNum.FlightId;
			//	return selected;
			//}
			//else
			//{
			//	throw new Exception();
			//}

			return Mapper.Map<Ticket, TicketDTO>( await IunitOfWork.TicketRepository.Get(id)); 
			
		}
		public async Task DeleteTicketById(int id)
		{
			await IunitOfWork.TicketRepository.Delete(id);
		}
		public async Task CreateTicket(TicketDTO item)
		{
			//Ticket temp = Mapper.Map<TicketDTO, Ticket>(item);
			//temp.FlightNum = IunitOfWork.FlightRepository.Get(item.FlightNum);
			//if(temp.FlightNum != null)
			//{
			//	IunitOfWork.TicketRepository.Create(temp);
			//}
			//else
			//{
			//	throw new Exception();
			//}

			await IunitOfWork.TicketRepository.Create(Mapper.Map<TicketDTO, Ticket>(item));


			
		}
		public async Task UpdateTicket(int id, TicketDTO item)
		{
			await IunitOfWork.TicketRepository.Update(id, Mapper.Map<TicketDTO, Ticket>(item));
		}
	}
}
