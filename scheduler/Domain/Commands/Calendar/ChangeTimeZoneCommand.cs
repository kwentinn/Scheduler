using System;

namespace Scheduler.Domain.Commands.Calendar
{
	public class ChangeTimeZoneCommand
	{
		public TimeZoneInfo CalendarTimeZone { get; }

		public ChangeTimeZoneCommand(TimeZoneInfo calendarTimeZone)
		{
			CalendarTimeZone = calendarTimeZone ?? throw new ArgumentNullException(nameof(calendarTimeZone));
		}
	}
}
