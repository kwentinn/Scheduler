using Scheduler.Domain.Commands.AppointmentCommands;

namespace Scheduler.Domain.Policies
{
	public class PlanAppointmentPolicy : IPolicy<PlanNewAppointment, Appointment>
	{

		public PlanAppointmentPolicy()
		{
		}

		public PolicyResult CanExecute(Appointment aggregateRoot)
		{

			return new PolicyResult { CanExecute = true };
		}
	}
}
