using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class CalendarCreatedEvent : DomainEvent
	{
		public string Title { get; private set; }
		public string TimeZone { get; }

		public CalendarCreatedEvent(Guid calendarId, string title, string timeZone)
		{
			AggregateRootId = calendarId;
			Title = title;
			TimeZone = timeZone;
		}
	}
}
