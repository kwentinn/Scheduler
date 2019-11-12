using System;
using System.Text.Json.Serialization;

namespace Scheduler.Reporting.Data.Entities
{
	public class CalendarOrganiserEntity
	{
		public Guid CalendarId { get; set; }
		public Guid UserId { get; set; }

		[JsonIgnore]
		public CalendarEntity Calendar { get; set; }

		[JsonIgnore]
		public UserEntity User { get; set; }
	}
}
