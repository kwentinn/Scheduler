using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Commands.Calendar
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
