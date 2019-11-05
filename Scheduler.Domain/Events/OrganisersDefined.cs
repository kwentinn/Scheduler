using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain.Events
{
	public class OrganisersDefined : DomainEvent
	{
		public List<User> Organisers { get; }
		public OrganisersDefined(Guid calendarId, List<User> organisers)
		{
			AggregateRootId = calendarId;
			Organisers = organisers;
		}
	}
}
