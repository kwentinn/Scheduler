using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class AppointmentAddedToCalendar : DomainEvent
	{
		public Guid CalendarId { get; }
		public string AppointmentTitle { get; }
		public DateTime AppointmentStartUtc { get; }
		public DateTime AppointmentEndUtc { get; }

		public AppointmentAddedToCalendar()
		{

		}
		public AppointmentAddedToCalendar(Guid calendarId, string appointmentTitle, DateTime appointmentStartUtc, DateTime appointmentEndUtc)
		{
			CalendarId = calendarId;
			AppointmentTitle = appointmentTitle;
			AppointmentStartUtc = appointmentStartUtc;
			AppointmentEndUtc = appointmentEndUtc;
		}
	}
}
