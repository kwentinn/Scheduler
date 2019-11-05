using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class ChangeCalendarTimeZone : DomainCommand<Calendar>
	{
		public TimeZoneInfo CalendarTimeZone { get; }

		public ChangeCalendarTimeZone(Guid calendarId, TimeZoneInfo calendarTimeZone)
		{
			AggregateRootId = calendarId;
			CalendarTimeZone = calendarTimeZone ?? throw new ArgumentNullException(nameof(calendarTimeZone));
		}
	}
}
