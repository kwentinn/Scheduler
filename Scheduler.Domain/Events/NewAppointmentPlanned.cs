using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class NewAppointmentPlanned : DomainEvent
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public Guid CalendarId { get; set; }
	}
}
