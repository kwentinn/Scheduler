using System;
using System.Collections.Generic;

namespace Scheduler.Reporting.Data.Entities
{
	public class CalendarEntity
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public bool IsArchived { get; set; }
		public string TimeZoneCode { get; set; }

		public DateTime UtcCreatedAt { get; set; }
		public DateTime? UtcLastUpdate { get; set; }

		//public virtual ICollection<UserEntity> Organisers { get; set; }
	}
}
