using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class ArchiveCalendarCommand : DomainCommand<Calendar>
	{
		public ArchiveCalendarCommand(Guid calendarId)
		{
			AggregateRootId = calendarId;
		}
	}
}
