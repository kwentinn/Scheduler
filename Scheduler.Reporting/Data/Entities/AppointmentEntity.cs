using System;
using System.Collections.Generic;

namespace Scheduler.Reporting.Data.Entities
{
	public class AppointmentEntity
	{
		public Guid Id { get; set; }
		public DateTime	UtcStart { get; set; }
		public DateTime	UtcEnd { get; set; }

		public virtual ICollection<UserEntity> Attendees { get; set; }
	}
}
