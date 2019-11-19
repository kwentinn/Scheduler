﻿using Kledex.Domain;
using Scheduler.Domain.Commands.AppointmentCommands;
using Scheduler.Domain.Repositories;
using System.Threading.Tasks;

namespace Scheduler.Domain.Policies
{
	public class PlanAppointmentPolicy : IPolicy<PlanNewAppointment, Appointment>
	{
		private readonly IRepository<Calendar> _calendarRepository;
		private readonly IAppointmentRepository _appointmentRepository;

		public PlanAppointmentPolicy(IRepository<Calendar> calendarRepository, IAppointmentRepository appointmentRepository)
		{
			_calendarRepository = calendarRepository;
			_appointmentRepository = appointmentRepository;
		}

		public async Task<PolicyResult> CanExecuteAsync(PlanNewAppointment command, Appointment aggregateRoot)
		{
			// To be able to plan a new appointment, the following conditions must be met:

			// 1. the associated calendar must not be archived
			// ----> we can know this by loading the Calendar from its repository
			var calendar = await _calendarRepository.GetByIdAsync(aggregateRoot.CalendarId);
			if (calendar.IsArchived)
			{
				return new PolicyResult
				{
					CanExecute = false,
					Reason = "The associated calendar is archived."
				};
			}

			// 2. the owner must be available at the new appointment's period
			if (_appointmentRepository.HasAppointmentForPeriod(aggregateRoot.CalendarId, aggregateRoot.UtcPeriod))
			{
				return new PolicyResult
				{
					CanExecute = false,
					Reason = "An appointment has already been scheduled at this period."
				};
			}

			return new PolicyResult { CanExecute = true };
		}
	}
}
