using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class ChangeCalendarTimeZoneCommand : DomainCommand<Calendar>
	{
		public TimeZoneInfo CalendarTimeZone { get; }

		public ChangeCalendarTimeZoneCommand(Guid calendarId, TimeZoneInfo calendarTimeZone)
		{
			AggregateRootId = calendarId;
			CalendarTimeZone = calendarTimeZone ?? throw new ArgumentNullException(nameof(calendarTimeZone));
		}
	}
}
