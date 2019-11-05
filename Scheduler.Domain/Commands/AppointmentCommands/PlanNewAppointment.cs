using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class PlanNewAppointment : DomainCommand<Calendar>
	{
		public string AppointmentTitle { get; }
		public DateTime AppointmentStartUtc { get; }
		public DateTime AppointmentEndUtc { get; }
		public Guid CalendarId { get; set; }

		public PlanNewAppointment(Guid appointmentId, Guid calendarId, string appointmentTitle, DateTime appointmentStartUtc, DateTime appointmentEndUtc)
		{
			if (appointmentId == Guid.NewGuid()) throw new ArgumentException(nameof(appointmentId));
			if (calendarId == Guid.NewGuid()) throw new ArgumentException(nameof(calendarId));

			AggregateRootId = appointmentId;
			CalendarId = calendarId;
			AppointmentTitle = appointmentTitle;
			AppointmentStartUtc = appointmentStartUtc;
			AppointmentEndUtc = appointmentEndUtc;
		}
	}
}
