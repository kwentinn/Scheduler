using System;
using System.Collections.Generic;

namespace Scheduler.Reporting.Data.Entities
{
	public class AppointmentEntity
	{
		public Guid Id { get; set; }
		public Guid CalendarId { get; set; }
		public string Title { get; set; }
		public DateTime UtcStart { get; set; }
		public DateTime UtcEnd { get; set; }

		public DateTime UtcCreatedAt { get; set; }

		public CalendarEntity Calendar { get; set; }
		public virtual ICollection<UserEntity> Attendees { get; set; }
	}
}
