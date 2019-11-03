using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class AppointmentAddedToCalendar : DomainEvent
	{
		public Guid	CalendarId { get; set; }
		public string AppointmentTitle { get; set; }
		public DateTime AppointmentStartUtc { get; set; }
		public DateTime AppointmentEndUtc { get; set; }
	}
}
