using Kledex.Commands;
using Kledex.Domain;
using Scheduler.Domain.Commands.CalendarCommands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.CalendarCmdHdlrs
{
	public class DefineOrganisersHandler : ICommandHandlerAsync<DefineOrganisers>
	{
		private IRepository<Calendar> _calendarRepository;
		private IRepository<User> _userRepository;

		public DefineOrganisersHandler(IRepository<Calendar> calendarRepository, IRepository<User> userRepository)
		{
			_calendarRepository = calendarRepository;
			_userRepository = userRepository;
		}

		public async Task<CommandResponse> HandleAsync(DefineOrganisers command)
		{
			// récup du calendrier
			var calendar = await _calendarRepository.GetByIdAsync(command.AggregateRootId);
			if (calendar == null)
			{
				throw new ApplicationException($"Cannot find calendar (${command.AggregateRootId})");
			}

			// récup des users par leurs ids
			var users = new List<User>();
			foreach (var userId in command.OrganisersIds)
			{
				var user = await _userRepository.GetByIdAsync(userId);
				if (user == null)
				{
					throw new ApplicationException($"User not found ({userId})");
				}
				users.Add(user);
			}

			// on joue l'action sur l'objet du domaine
			calendar.DefineOrganisers(users);

			// on retourne la réponse contenant les évènements
			return new CommandResponse
			{
				Events = calendar.Events
			};
		}
	}
}
