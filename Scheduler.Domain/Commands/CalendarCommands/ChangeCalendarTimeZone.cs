using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class ChangeCalendarTimeZone : DomainCommand<Calendar>
	{
		public TimeZoneInfo CalendarTimeZone { get; set; }
	}
}
