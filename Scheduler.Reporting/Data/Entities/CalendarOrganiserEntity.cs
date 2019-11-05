using System;

namespace Scheduler.Reporting.Data.Entities
{
	public class CalendarOrganiserEntity
	{
		public Guid CalendarId { get; set; }
		public Guid UserId { get; set; }

		public CalendarEntity Calendar { get; set; }
	}
}
