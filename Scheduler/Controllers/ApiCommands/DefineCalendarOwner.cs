using System;

namespace Scheduler.Controllers.ApiCommands
{
	public class DefineCalendarOwner
	{
		public Guid CalendarId { get; set; }
		public Guid OwnerId { get; set; }
	}
}
