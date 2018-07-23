using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using BSA_2018_Homework_4.DTOs;
using BSA_2018_Homework_4.DTOs.InputDTOs;
using BSA_2018_Homework_4.DAL.Models;
using AutoMapper;
using BSA_2018_Homework_4.DTOs.DTOsForRemote;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;


namespace BSA_2018_Homework_4.BL.Services
{
    public class CrewService : ICrewService
    {
		//private ICrewRepository crewRepository;
		private DAL.IUnitOfWork IunitOfWork;

		public CrewService(DAL.IUnitOfWork IunitOfWork)
		{
			this.IunitOfWork = IunitOfWork;
		}

		public async Task CreateCrew(InputCrewDTO item)
		{
			Crew temp = new Crew();
			temp.PilotId = await IunitOfWork.PilotRepository.Get(item.PilotId);

			List<Stewardess> tempS = await IunitOfWork.StewardessRepository.GetAll();
			List<Stewardess> selected = new List<Stewardess>();
			foreach (Stewardess s in tempS)
			{
				foreach (int i in item.StewardessIds)
				{
					if (s.Id == i)
						selected.Add(s);
				}

			}
			temp.StewardessIds = selected;

			if (temp.StewardessIds.Count == item.StewardessIds.Count() && temp.PilotId != null)
			{
				await IunitOfWork.CrewRepository.Create(temp);
			}
			else
			{
				throw new Exception();
			}


			//await IunitOfWork.CrewRepository.Create(Mapper.Map<InputCrewDTO,Crew>(item));

		}

		public async Task DeleteCrewById(int id)
		{
			await IunitOfWork.CrewRepository.Delete(id);
		}

		public async Task<CrewDTO> GetCrewById(int id)
		{
			return Mapper.Map<Crew, CrewDTO>(await IunitOfWork.CrewRepository.Get(id));
		}

		public async Task<List<CrewDTO>> GetCrewCollection()
		{
			//List<Crew> temp = IunitOfWork.CrewRepository.GetAll();
			//List<CrewDTO> selected = Mapper.Map<List<Crew>, List<CrewDTO>>(temp);

			//List<Stewardess> tempS = new List<Stewardess>();
			//List<Stewardess> stw = IunitOfWork.StewardessRepository.GetAll();

			//foreach 

			//List<CrewDTO> selected

			//List<CrewDTO> crewDTOs = Mapper.Map<List<Crew>, List<CrewDTO>>(IunitOfWork.CrewRepository.GetAll());

			return Mapper.Map<List<Crew>, List<CrewDTO>>(await IunitOfWork.CrewRepository.GetAll());// crewDTOs;
		}

		public async Task UpdateCrew(int id, InputCrewDTO item)
		{
			Crew temp = new Crew();
			temp.PilotId = await IunitOfWork.PilotRepository.Get(item.PilotId);

			List<Stewardess> tempS = await IunitOfWork.StewardessRepository.GetAll();
			List<Stewardess> selected = new List<Stewardess>();
			foreach (Stewardess s in tempS)
			{
				foreach (int i in item.StewardessIds)
				{
					if (s.Id == i)
						selected.Add(s);
				}

			}
			temp.StewardessIds = selected;

			if (temp.StewardessIds.Count == item.StewardessIds.Count() && temp.PilotId != null)
			{
				await IunitOfWork.CrewRepository.Update(id, temp);
			}
			else
			{
				throw new Exception();
			}
		}

		public async Task SpecialFunction()
		{
			string api = "http://5b128555d50a5c0014ef1204.mockapi.io/crew";

			HttpClient httpClient = new HttpClient();
			HttpResponseMessage response = await httpClient.GetAsync(api);
			HttpContent content = response.Content;

			string temp = await content.ReadAsStringAsync();
			RemoteCrewDTO[] crews = JsonConvert.DeserializeObject<RemoteCrewDTO[]>(temp);

			Array.Resize(ref crews, 10);


			crewList = new List<Crew>();


			foreach (RemoteCrewDTO rcdto in crews)
			{

				Pilot p = new Pilot()
				{
					Name = rcdto.pilot[0].firstName,
					Surname = rcdto.pilot[0].lastName,
					Birth = rcdto.pilot[0].birthDate,
					Experience = new TimeSpan(rcdto.pilot[0].exp)
				};


				List<Stewardess> ls = new List<Stewardess>();

				for (int i = 0; i < rcdto.stewardess.Count(); i++)
				{
					ls.Add(
						new Stewardess()
						{
							Name = rcdto.stewardess[i].firstname,
							Surname = rcdto.stewardess[i].lastName,
							Birth = rcdto.stewardess[i].birthDate
						});
				}


				crewList.Add(
					new Crew()
					{
						PilotId = p,
						StewardessIds = ls
					});
			}



			//Task task1 = new Task(DB_Adding);
			//Task task2 = new Task()


			//task1.Start();

			//List<Task> coll = new List<Task>();
			//coll.Append(await DB_Adding());,await FileWriting());

			//await Task.WhenAll(await DB_Adding,)



			Task x = DB_Adding();
			Task y = FileWriting();

			await Task.WhenAll(x, y);
		}

		private static List<Crew> crewList;






		private async Task DB_Adding()
		{
			foreach (Crew c in crewList)
			{
				await IunitOfWork.CrewRepository.Create(c);
			}			
		}

		private async Task FileWriting()
		{
			string path = Environment.CurrentDirectory + "\\dirLog\\upd_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".csv";
			StreamWriter sw = new StreamWriter(path);
			foreach (Crew c in crewList)
			{
				var line = string.Format("{0}, {1}, {2}", c.PilotId.Name, c.PilotId.Surname, c.StewardessIds.Count);
				await sw.WriteLineAsync(line);
				sw.Flush();
			}
		}

	}
}
