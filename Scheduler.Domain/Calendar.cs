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
		public Calendar(Guid id, string name, string timeZone = "Romance Standard Time") : base(id)
		{
			if (id == Guid.Empty) throw new ApplicationException("id is invalid.");
			if (string.IsNullOrEmpty(name)) throw new ApplicationException("Calendar name is required");

			// si le timezone est bidon, ça pètera ici sans envoyer l'event of course
			TimeZoneInfo.FindSystemTimeZoneById(timeZone);

			AddAndApplyEvent(new CalendarCreatedEvent(id, name, timeZone));
		}

		public void Archive()
		{
			if (IsArchived) throw new ApplicationException("Calendar is already archived");

			AddAndApplyEvent(new CalendarArchivedEvent(Id));
		}

		public void DefineOrganisers(List<User> organisers)
		{
			if (organisers == null || organisers.Count == 0) throw new ArgumentException(nameof(organisers));

			AddAndApplyEvent(new OrganisersDefined(Id, organisers));
		}

		private void Apply(CalendarCreatedEvent @event)
		{
			Id = @event.AggregateRootId;
			Name = @event.Title;
			TimeZone = TimeZoneInfo.FindSystemTimeZoneById(@event.TimeZone);
		}
		private void Apply(CalendarArchivedEvent @event)
		{
			IsArchived = true;
		}
		private void Apply(OrganisersDefined @event)
		{
			Organisers.AddRange(@event.Organisers);
		}
	}
}
