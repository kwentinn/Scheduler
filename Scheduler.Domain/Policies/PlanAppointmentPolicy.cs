using Kledex.Domain;
using Scheduler.Domain.Commands.AppointmentCommands;
using System.Threading.Tasks;

namespace Scheduler.Domain.Policies
{
	public class PlanAppointmentPolicy : IPolicy<PlanNewAppointment, Appointment>
	{
		private readonly IRepository<Calendar> _calendarRepository;

		public PlanAppointmentPolicy(IRepository<Calendar> calendarRepository)
		{
			this._calendarRepository = calendarRepository;
		}

		public async Task<PolicyResult> CanExecuteAsync(Appointment aggregateRoot)
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


			return new PolicyResult { CanExecute = true };
		}
	}
}
