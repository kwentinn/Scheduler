using Kledex.Commands;
using Kledex.Domain;
using Scheduler.Domain.Commands.CalendarCommands;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.CalendarCmdHdlrs
{
	public class DefineNewCalendarHandler : ICommandHandlerAsync<DefineNewCalendarCommand>
	{
		private readonly IRepository<Calendar> _calendarRepository;

		public DefineNewCalendarHandler(IRepository<Calendar> calendarRepository)
		{
			_calendarRepository = calendarRepository;
		}

		public async Task<CommandResponse> HandleAsync(DefineNewCalendarCommand command)
		{
			// création de l'instance
			var calendar = new Calendar(command.AggregateRootId, command.CalendarName);

			//... et sauvegarde (sans event sourcing)
			await _calendarRepository.SaveAsync(calendar);

			// on renvoie une liste d'évènements
			return new CommandResponse
			{
				Events = calendar.Events
			};
		}
	}
}
