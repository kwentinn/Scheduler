using Kledex.Commands;
using Kledex.Domain;
using System.Threading.Tasks;

namespace Scheduler.Domain.Commands.Handlers
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
