using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class ArchiveCalendar : DomainCommand<Calendar>
	{
		public ArchiveCalendar()
		{
				
		}
		public ArchiveCalendar(Guid calendarId)
		{
			AggregateRootId = calendarId;
		}
	}
}
