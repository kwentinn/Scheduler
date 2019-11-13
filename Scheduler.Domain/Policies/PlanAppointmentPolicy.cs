using Scheduler.Domain.Commands.AppointmentCommands;

namespace Scheduler.Domain.Policies
{
	public class PlanAppointmentPolicy : IPolicy<PlanNewAppointment, Appointment>
	{

		public PlanAppointmentPolicy()
		{
		}

		public bool CanExecute(Appointment aggregateRoot)
		{
			return true;
		}
	}
}
