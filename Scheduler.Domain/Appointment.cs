using Itenso.TimePeriod;
using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain
{
	public class Appointment
	{
		public int Id { get; set; }
		public string Title { get; private set; }
		public TimeRange UtcPeriod { get; private set; }

		public int MaxAttendees { get; private set; }
		public bool IsCanceled { get; private set; }
		public bool SendReminder { get; private set; }
		public AppointmentStatus AppointmentStatus { get; private set; }
		public string ConferenceUri { get; private set; }
		public string ConferenceUriForOrganiser { get; private set; }

		public List<Participant> Participants { get; private set; } = new List<Participant>();

		public Appointment(string title, TimeRange utcPeriod)
		{
			if (string.IsNullOrEmpty(title))
				throw new ArgumentException(nameof(title));

			Title = title;
			UtcPeriod = utcPeriod ?? throw new ArgumentNullException(nameof(utcPeriod));
			AppointmentStatus = AppointmentStatus.Draft;
		}

		#region actions
		public void ChangeTitle(string title) { Title = title; }
		public void Cancel() { IsCanceled = true; }
		public void Postpone(TimeRange utcPeriod) { UtcPeriod = utcPeriod; }
		public void AddParticipant(Participant p) { Participants.Add(p); }
		public void RemoveParticipant(Participant p) { Participants.Remove(p); }
		public void ChangeMaxAttendees(int maxAttendees) { MaxAttendees = maxAttendees; }
		public void ChangeMustSendReminder(bool sendReminder) { SendReminder = sendReminder; }
		#endregion
	}

	public enum AppointmentStatus
	{
		Draft,
		Accepted,
		Canceled
	}
}
