using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands
{
	public class ChangeTimeZoneCommand : DomainCommand<Calendar>
	{
		public TimeZoneInfo CalendarTimeZone { get; }

		public ChangeTimeZoneCommand(TimeZoneInfo calendarTimeZone)
		{
			CalendarTimeZone = calendarTimeZone ?? throw new ArgumentNullException(nameof(calendarTimeZone));
		}
	}
}
