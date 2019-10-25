using System;

namespace Scheduler.Commands.Calendar
{
	public class DefineNewCalendarCommand
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
