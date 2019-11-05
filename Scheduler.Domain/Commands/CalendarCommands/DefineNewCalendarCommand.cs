using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class DefineNewCalendarCommand : DomainCommand<Calendar>
	{
		public string CalendarName { get; }
		public TimeZoneInfo CalendarTimeZone { get; }

		public DefineNewCalendarCommand(Guid calendarId, string calendarName, TimeZoneInfo calendarTimeZone)
		{
			AggregateRootId = calendarId;
			CalendarName = calendarName;
			CalendarTimeZone = calendarTimeZone ?? throw new ArgumentNullException(nameof(calendarTimeZone));
		}
	}
}
