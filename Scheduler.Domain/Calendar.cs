using Kledex.Domain;
using Scheduler.Domain.Events;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain
{
	public class Calendar : AggregateRoot
	{
		public string Name { get; private set; }
		public bool IsArchived { get; private set; }
		public TimeZoneInfo TimeZone { get; private set; }

		//public List<Appointment> Appointments { get; private set; }

		public List<User> Organisers { get; private set; }

		public Calendar() { }
		public Calendar(Guid id, string name) : base(id)
		{
			if (string.IsNullOrEmpty(name)) throw new ApplicationException("Calendar name is required");

			AddAndApplyEvent(new NewCalendarDefinedEvent(id, name));
		}

		public void Archive()
		{
			if (IsArchived) throw new ApplicationException("Calendar already archived");

			AddAndApplyEvent(new CalendarArchivedEvent());
		}

		#region Apply methods (event sourcing)

		public void Apply(NewCalendarDefinedEvent @event)
		{
			Id = @event.Id;
			Name = @event.Title;
		}
		public void Apply(CalendarArchivedEvent @event)
		{
			IsArchived = true;
		}

		#endregion
	}
}
