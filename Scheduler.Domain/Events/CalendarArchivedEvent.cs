﻿using System;
using Kledex.Domain;

namespace Scheduler.Domain.Events
{
	public class CalendarArchivedEvent : DomainEvent
	{
		public CalendarArchivedEvent(Guid id)
		{
			AggregateRootId = id;
		}
	}
}
