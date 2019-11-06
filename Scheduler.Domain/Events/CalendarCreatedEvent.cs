using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class CalendarCreatedEvent : DomainEvent
	{
		public string Title { get; set; }
		public string TimeZone { get; set; }

		public CalendarCreatedEvent()
		{
		}
		//public CalendarCreatedEvent(Guid calendarId, string title, string timeZone)
		//{
		//	AggregateRootId = calendarId;
		//	Title = title;
		//	TimeZone = timeZone;
		//}
	}
}
