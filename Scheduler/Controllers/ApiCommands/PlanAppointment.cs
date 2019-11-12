using System;

namespace Scheduler.Controllers.ApiCommands
{
	public class PlanAppointment
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime UtcStart { get; set; }
		public DateTime UtcEnd { get; set; }
		public Guid CalendarId { get; set; }
	}
}
