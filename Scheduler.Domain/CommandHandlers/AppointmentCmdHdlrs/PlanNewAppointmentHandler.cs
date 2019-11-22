using Itenso.TimePeriod;
using Kledex.Commands;
using Scheduler.Domain.Commands.AppointmentCommands;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.AppointmentCmdHdlrs
{
	public class PlanNewAppointmentHandler : ICommandHandlerAsync<PlanNewAppointment>
	{
		public async Task<CommandResponse> HandleAsync(PlanNewAppointment command)
		{
			var appointment = new Appointment
			(
				command.AggregateRootId,
				command.Title,
				command.Description,
				new TimeRange(command.UtcStart, command.UtcEnd),
				command.CalendarId
			);

			// and return a command reponse containing the new id
			return await Task.FromResult(new CommandResponse
			{
				Events = appointment.Events,
				Result = command.AggregateRootId
			});
		}
	}
}
