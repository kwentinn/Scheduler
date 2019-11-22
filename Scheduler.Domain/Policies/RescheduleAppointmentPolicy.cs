using Kledex.Domain;
using Scheduler.Domain.Commands.AppointmentCommands;
using Scheduler.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Scheduler.Domain.Policies
{
	public class RescheduleAppointmentPolicy : IPolicy<RescheduleAppointment>
	{
		private readonly IRepository<Calendar> _calendarRepository;
		private readonly IAppointmentRepository _appointmentRepository;

		public RescheduleAppointmentPolicy(IRepository<Calendar> calendarRepository, IAppointmentRepository appointmentRepository)
		{
			_calendarRepository = calendarRepository;
			_appointmentRepository = appointmentRepository;
		}

		public async Task<PolicyResult> CanExecuteAsync(RescheduleAppointment command)
		{
			// 1. the associated calendar must not be archived
			// ----> we can know this by loading the Calendar from its repository
			var calendar = await _calendarRepository.GetByIdAsync(command.CalendarId);
			if (calendar.IsArchived)
			{
				return new PolicyResult
				{
					CanExecute = false,
					Reason = "The associated calendar is archived."
				};
			}

			if (_appointmentRepository.HasAppointmentForPeriod(command.CalendarId, command.NewUtcPeriod))
			{
				return new PolicyResult
				{
					CanExecute = false,
					Reason = "An appointment has already been scheduled at this period."
				};
			}

			return new PolicyResult { CanExecute = true };
		}
		public PolicyResult CanExecute(RescheduleAppointment command)
		{
			throw new NotImplementedException();
		}
	}
}
