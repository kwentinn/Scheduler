using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class CalendarOwnerDefined : DomainEvent
	{
		public Guid OwnerId { get; set; }
	}
}
