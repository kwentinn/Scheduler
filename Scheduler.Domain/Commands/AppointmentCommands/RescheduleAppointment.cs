using System;
using Itenso.TimePeriod;
using Kledex.Domain;

namespace Scheduler.Domain.Commands.AppointmentCommands
{
	public class RescheduleAppointment : DomainCommand<Appointment>
	{
		public TimeRange NewUtcPeriod { get; set; }
		public Guid CalendarId { get; set; }
	}
}
