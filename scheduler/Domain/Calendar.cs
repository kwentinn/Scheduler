using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Domain
{
	public class Calendar
	{
		public int Id { get; set; }
		public string Name { get; private set; }
		public bool IsArchived { get; private set; }
		public TimeZoneInfo TimeZone { get; private set; }

		public List<Appointment> Appointments { get; private set; }
		public List<Organiser> Organisers { get; private set; }
	}
}
