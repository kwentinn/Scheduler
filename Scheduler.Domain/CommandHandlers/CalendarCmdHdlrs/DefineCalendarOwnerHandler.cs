using Kledex.Commands;
using Kledex.Domain;
using Scheduler.Domain.Commands.CalendarCommands;
using System;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.CalendarCmdHdlrs
{
	public class DefineCalendarOwnerHandler : ICommandHandlerAsync<DefineCalendarOwner>
	{
		private IRepository<Calendar> _calendarRepository;
		private IRepository<User> _userRepository;

		public DefineCalendarOwnerHandler(IRepository<Calendar> calendarRepository, IRepository<User> userRepository)
		{
			_calendarRepository = calendarRepository;
			_userRepository = userRepository;
		}

		public async Task<CommandResponse> HandleAsync(DefineCalendarOwner command)
		{
			// récup du calendrier
			var calendar = await _calendarRepository.GetByIdAsync(command.AggregateRootId);
			if (calendar == null)
			{
				throw new ApplicationException($"Cannot find calendar (${command.AggregateRootId})");
			}

			// récup des users par leurs ids

			var user = await _userRepository.GetByIdAsync(command.OwnerId);
			if (user == null)
			{
				throw new ApplicationException($"User not found ({command.OwnerId})");
			}

			// on joue l'action sur l'objet du domaine
			calendar.DefineOrganiser(user);

			// on retourne la réponse contenant les évènements
			return new CommandResponse
			{
				Events = calendar.Events
			};
		}
	}
}
