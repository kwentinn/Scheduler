using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands
{
	public class DefineNewCalendarCommand : DomainCommand
	{
		public string CalendarName { get; }
		public TimeZoneInfo CalendarTimeZone { get; }

		public DefineNewCalendarCommand(string calendarName, TimeZoneInfo calendarTimeZone)
		{
			CalendarName = calendarName;
			CalendarTimeZone = calendarTimeZone ?? throw new ArgumentNullException(nameof(calendarTimeZone));
		}
	}
}
