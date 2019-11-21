using Itenso.TimePeriod;
using Kledex.Commands;
using Kledex.Domain;
using Scheduler.Domain.Commands.AppointmentCommands;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.AppointmentCmdHdlrs
{
	public class PlanNewAppointmentHandler : ICommandHandlerAsync<PlanNewAppointment>
	{
		private readonly IRepository<Appointment> _repository;

		public PlanNewAppointmentHandler(IRepository<Appointment> repository)
		{
			_repository = repository;
		}

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

			// if success, we save the event to the store
			await _repository.SaveAsync(appointment);

			// and return a command reponse containing the new id
			return new CommandResponse
			{
				Events = appointment.Events,
				Result = command.AggregateRootId
			};
		}
	}
}
