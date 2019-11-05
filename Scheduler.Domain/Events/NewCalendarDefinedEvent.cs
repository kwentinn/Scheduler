using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class NewCalendarDefinedEvent : DomainEvent
	{
		public string Title { get; private set; }

		public NewCalendarDefinedEvent(Guid aggregateRootId, string name)
		{
			AggregateRootId = aggregateRootId;
			this.Title = name;
		}
	}
}
