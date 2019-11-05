using Itenso.TimePeriod;
using Kledex.Domain;
using Scheduler.Domain.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Scheduler.Domain
{
	public class Appointment : AggregateRoot
	{
		public string Title { get; private set; }
		public TimeRange UtcPeriod { get; private set; }
		public AppointmentStatus Status { get; private set; }
		public Guid CalendarId { get; set; }

		public ReadOnlyCollection<User> Participants { get; private set; }

		public Appointment() { }
		public Appointment(Guid id, string title, TimeRange utcPeriod)
		{
			// vérifications d'usage :)
			if (string.IsNullOrEmpty(title)) throw new ArgumentException(nameof(title));
			if (UtcPeriod.IsMoment) throw new ApplicationException("The period is invalid because it is a moment (start = end).");
			if (UtcPeriod.IsAnytime) throw new ApplicationException("The period is invalid because it is not defined.");

			AddAndApplyEvent(new NewAppointmentPlannedEvent()
			{
				AggregateRootId = id,
				Title = title,
				Start = utcPeriod.Start,
				End = utcPeriod.End
			});
		}


		public void Cancel()
		{
			if (Status != AppointmentStatus.Accepted)
				throw new ApplicationException($"Cannot cancel because appointment is not accepted (current state: ${Status}).");

			Status = AppointmentStatus.Canceled;
		}

		private void Apply(NewAppointmentPlannedEvent @event)
		{
			Id = @event.AggregateRootId;
			Title = @event.Title;
			UtcPeriod = new TimeRange(@event.Start, @event.End);

			Status = AppointmentStatus.Draft;
		}
	}

	public enum AppointmentStatus
	{
		Draft,
		Accepted,
		Canceled
	}
}
