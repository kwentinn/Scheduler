using Kledex.Commands;
using Kledex.Domain;
using Scheduler.Domain.Commands.CalendarCommands;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.CalendarCmdHdlrs
{
	public class CreateNewCalendarHandler : ICommandHandlerAsync<CreateNewCalendarCommand>
	{
		private readonly IRepository<Calendar> _calendarRepository;

		public CreateNewCalendarHandler(IRepository<Calendar> calendarRepository)
		{
			_calendarRepository = calendarRepository;
		}

		public async Task<CommandResponse> HandleAsync(CreateNewCalendarCommand command)
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
