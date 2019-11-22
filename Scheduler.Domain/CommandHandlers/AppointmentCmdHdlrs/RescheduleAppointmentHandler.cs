using Kledex.Commands;
using Kledex.Domain;
using Scheduler.Domain.Commands.AppointmentCommands;
using System;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.AppointmentCmdHdlrs
{
	public class RescheduleAppointmentHandler : ICommandHandlerAsync<RescheduleAppointment>
	{
		private readonly IRepository<Appointment> _repository;

		public RescheduleAppointmentHandler(IRepository<Appointment> repository)
		{
			_repository = repository;
		}

		public async Task<CommandResponse> HandleAsync(RescheduleAppointment command)
		{
			// the appointment must exist
			var appointment = await _repository.GetByIdAsync(command.AggregateRootId);
			if (appointment == null)
			{
				throw new ApplicationException($"Cannot find appointment (id: {command.AggregateRootId}).");
			}

			appointment.Reschedule(command);

			// and return a command reponse containing the new id
			return new CommandResponse
			{
				Events = appointment.Events,
				Result = command.AggregateRootId
			};
		}
	}
}
