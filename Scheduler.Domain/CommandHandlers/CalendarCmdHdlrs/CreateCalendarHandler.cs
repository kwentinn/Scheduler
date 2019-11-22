using Kledex.Commands;
using Scheduler.Domain.Commands.CalendarCommands;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.CalendarCmdHdlrs
{
	public class CreateCalendarHandler : ICommandHandlerAsync<CreateCalendar>
	{
		public async Task<CommandResponse> HandleAsync(CreateCalendar command)
		{
			// création de l'instance
			var calendar = new Calendar(command.AggregateRootId, command.Title, command.TimeZone);

			// on renvoie une liste d'évènements
			return await Task.FromResult(new CommandResponse
			{
				Events = calendar.Events,
				Result = calendar.Id
			});
		}
	}
}
