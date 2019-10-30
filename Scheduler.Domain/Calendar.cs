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

		public List<Appointment> Appointments { get; private set; }
		public List<Organiser> Organisers { get; private set; }

		public Calendar() { }
		public Calendar(Guid id, string name) : base(id)
		{
			if (string.IsNullOrEmpty(name))
				throw new ApplicationException("Calendar name is required");

			// with event surcing
			AddAndApplyEvent(new NewCalendarDefinedEvent(id, name));

			// without event sourcing
			//Name = name;
		}

		public void Archive()
		{
			if (IsArchived)
				throw new ApplicationException("Calendar already archived");

			// with event surcing
			AddAndApplyEvent(new CalendarArchivedEvent());

			// without event sourcing
			//IsArchived = true;
		}

		#region Applys methods (event sourcing)
		public void Apply(NewCalendarDefinedEvent @event)
		{
			Id = @event.Id;
			Name = @event.Name;
		}
		public void Apply(CalendarArchivedEvent @event)
		{
			IsArchived = true;
		}
		#endregion
	}
}
