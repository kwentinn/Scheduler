using System;

namespace Scheduler.Controllers.ApiCommands
{
	public class RescheduleAppointment
	{
		public Guid AppointmentId { get; set; }
		public Guid CalendarId { get; set; }
		public DateTime NewUtcStart { get; set; }
		public DateTime NewUtcEnd { get; set; }
	}
}
