using Scheduler.Domain;
using System;
using System.Collections.Generic;

namespace Scheduler.Commands.Appointment
{
	public class DefineAttendeesCommand
	{
		public int AppointmentId { get; }
		public List<Participant> ParticipantsToAdd { get; }

		public DefineAttendeesCommand(int appointmentId, List<Participant> participantsToAdd)
		{
			if (participantsToAdd.Count == 0) throw new ArgumentException(nameof(participantsToAdd));

			AppointmentId = appointmentId;
			ParticipantsToAdd = participantsToAdd ?? throw new ArgumentNullException(nameof(participantsToAdd));
		}
	}
}
