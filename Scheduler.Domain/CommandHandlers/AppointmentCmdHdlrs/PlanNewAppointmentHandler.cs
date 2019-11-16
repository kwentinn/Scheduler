﻿using Itenso.TimePeriod;
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

		public PlanNewAppointmentHandler(IRepository<Appointment> repository, IPolicy<PlanNewAppointment, Appointment> appointmentPlanPolicy)
		{
			_repository = repository;
			_appointmentPlanPolicy = appointmentPlanPolicy;
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

			// Does the policy for the plan appointment command allow to create ?
			var result = await _appointmentPlanPolicy.CanExecuteAsync(appointment);
			if (!result.CanExecute)
			{
				throw new ApplicationException($"Cannot plan appointment ({ result.Reason }).");
			}

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
