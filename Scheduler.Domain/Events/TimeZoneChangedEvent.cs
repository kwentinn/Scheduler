using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class TimeZoneChangedEvent : DomainEvent
	{
		public string TimeZoneCode { get; }

		public TimeZoneChangedEvent()
		{

		}
		public TimeZoneChangedEvent(Guid calendarId, string timeZoneCode)
		{
			AggregateRootId = calendarId;
			TimeZoneCode = timeZoneCode;
		}
	}
}
