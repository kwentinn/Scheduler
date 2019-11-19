using Itenso.TimePeriod;
using Kledex.Domain;
using Scheduler.Domain.Commands.AppointmentCommands;
using Scheduler.Domain.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Scheduler.Domain
{
	public class Appointment : AggregateRoot
	{
		public string Title { get; private set; }
		public string Description { get; private set; }
		public TimeRange UtcPeriod { get; private set; }
		public AppointmentStatus Status { get; private set; }
		public Guid CalendarId { get; private set; }

		public List<User> _participants = new List<User>();
		public ReadOnlyCollection<User> Participants => _participants.AsReadOnly();

		public Appointment() { }
		public Appointment(Guid appointmentId, string title, string description, TimeRange utcPeriod, Guid calendarId)
		{
			// vérifications d'usage :)
			if (string.IsNullOrEmpty(title)) throw new ArgumentException(nameof(title));
			if (utcPeriod.IsMoment) throw new ApplicationException("The period is invalid because it is a moment (start = end).");
			if (utcPeriod.IsAnytime) throw new ApplicationException("The period is invalid because it is not defined.");

			AddAndApplyEvent(new NewAppointmentPlanned
			{
				AggregateRootId = appointmentId,
				Title = title,
				Description = description,
				Start = utcPeriod.Start,
				End = utcPeriod.End,
				CalendarId = calendarId
			});
		}

		public void Reschedule(RescheduleAppointment command)
		{
			//if (command.NewUtcPeriod.IsMoment) throw new ApplicationException("The new period is invalid because it is a moment (start = end).");
			//if (command.NewUtcPeriod.IsAnytime) throw new ApplicationException("The new period is invalid because it is not defined.");

			var evt = new AppointmentRescheduled
			{
				Id = Guid.NewGuid(),
				CommandId = command.Id,

				AggregateRootId = Id,
				NewUtcPeriod = command.NewUtcPeriod
			};

			AddAndApplyEvent(evt);
		}

		private void Apply(NewAppointmentPlanned @event)
		{
			Id = @event.AggregateRootId;
			Title = @event.Title;
			Description = @event.Description;
			UtcPeriod = new TimeRange(@event.Start, @event.End);
			CalendarId = @event.CalendarId;

			Status = AppointmentStatus.Draft;
		}
		private void Apply(AppointmentRescheduled @event)
		{
			UtcPeriod = @event.NewUtcPeriod;
		}

	}
}
