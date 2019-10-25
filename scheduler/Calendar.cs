using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain
{
	public class Calendar : AggregateRoot
	{
		public string Name { get; private set; }
		public bool IsArchived { get; private set; }
		public TimeZoneInfo TimeZone { get; private set; }

		public List<Appointment> Appointments { get; private set; }
		public List<Organiser> Organisers { get; private set; }

		public Calendar(Guid id, string name):base(id)
		{
			if (string.IsNullOrEmpty(name)) throw new ApplicationException("Calendar name is required");
			Name = name;
		}
	}
}
