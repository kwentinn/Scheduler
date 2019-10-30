namespace Scheduler.Domain.Commands.Appointment
{
	public class AcceptAppointment
	{
		public int AppointmentId { get; }

		public int ParticipantId { get; }
	}
}
