using Kledex.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Domain.Events
{
	public class NewAppointmentPlannedEvent : DomainEvent
	{
		public string Title { get; internal set; }
		public DateTime Start { get; internal set; }
		public DateTime End { get; internal set; }
	}
}
