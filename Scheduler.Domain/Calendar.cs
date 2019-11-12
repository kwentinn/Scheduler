using Kledex.Domain;
using Scheduler.Domain.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TimeZoneConverter;

namespace Scheduler.Domain
{
	public class Calendar : AggregateRoot
	{
		public string Name { get; private set; }
		public bool IsArchived { get; private set; }
		public TimeZoneInfo TimeZone { get; private set; }

		public List<Appointment> Appointments { get; private set; }

		private List<Guid> _organiserIds = new List<Guid>();
		public ReadOnlyCollection<Guid> OrganiserIds => _organiserIds.AsReadOnly();

		public Calendar()
		{
			_organiserIds = new List<Guid>();
		}
		public Calendar(Guid id, string name, string timeZone = "Romance Standard Time")
		{
			if (id == Guid.Empty) throw new ApplicationException("id is invalid.");
			if (string.IsNullOrEmpty(name)) throw new ApplicationException("Calendar name is required");

			_organiserIds = new List<Guid>();

			// si le timezone est bidon, ça pètera ici sans envoyer l'event of course
			TZConvert.GetTimeZoneInfo(timeZone);

			AddAndApplyEvent(new CalendarCreatedEvent
			{
				AggregateRootId = id,
				Title = name,
				TimeZone = timeZone
			});
		}


		public void Archive()
		{
			if (IsArchived) throw new ApplicationException("Calendar is already archived");

			AddAndApplyEvent(new CalendarArchivedEvent(Id));
		}
		public void DefineOrganiser(User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));

			AddAndApplyEvent(new CalendarOwnerDefined
			{
				AggregateRootId = Id,
				OwnerId = user.Id
			});
		}

		private void Apply(CalendarCreatedEvent @event)
		{
			Id = @event.AggregateRootId;
			Name = @event.Title;
			TimeZone = TZConvert.GetTimeZoneInfo(@event.TimeZone);
		}
		private void Apply(CalendarArchivedEvent @event)
		{
			IsArchived = true;
		}
		private void Apply(CalendarOwnerDefined @event)
		{
			_organiserIds.Add(@event.OwnerId);
		}
	}
}
