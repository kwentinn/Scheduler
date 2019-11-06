using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class NewAppointmentPlannedEvent : DomainEvent
	{
		public string Title { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }

		public NewAppointmentPlannedEvent()
		{

		}
	}
}
