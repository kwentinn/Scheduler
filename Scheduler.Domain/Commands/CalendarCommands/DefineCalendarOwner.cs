using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class DefineCalendarOwner : DomainCommand<Calendar>
	{
		public Guid OwnerId { get; set; }
	}
}
