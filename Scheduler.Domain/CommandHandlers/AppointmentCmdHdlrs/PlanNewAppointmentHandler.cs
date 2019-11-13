using Itenso.TimePeriod;
using Kledex.Commands;
using Kledex.Domain;
using Scheduler.Domain.Commands.AppointmentCommands;
using Scheduler.Domain.Policies;
using System;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.AppointmentCmdHdlrs
{
	public class PlanNewAppointmentHandler : ICommandHandlerAsync<PlanNewAppointment>
	{
		private readonly IRepository<Appointment> _repository;
		private readonly IPolicy<PlanNewAppointment, Appointment> _appointmentPlanPolicy;

		public PlanNewAppointmentHandler(IRepository<Appointment> repository, IPolicy<PlanNewAppointment, Appointment> _appointmentPlanPolicy)
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


			if (!_appointmentPlanPolicy.CanExecute(appointment))
			{
				throw new ApplicationException("Cannot plan appointment");
			}


			await _repository.SaveAsync(appointment);

			return new CommandResponse
			{
				Events = appointment.Events,
				Result = command.AggregateRootId
			};
		}
	}
}
