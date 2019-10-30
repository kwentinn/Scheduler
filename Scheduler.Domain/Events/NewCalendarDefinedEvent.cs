using Kledex.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Domain.Events
{
	public class NewCalendarDefinedEvent : DomainEvent
	{
		public string Name { get; private set; }

		public NewCalendarDefinedEvent(Guid aggregateRootId, string name)
		{
			AggregateRootId = aggregateRootId;
			this.Name = name;
		}
	}
}
