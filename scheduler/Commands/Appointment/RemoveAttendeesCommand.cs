using Scheduler.Domain;
using System;
using System.Collections.Generic;

namespace Scheduler.Commands.Appointment
{
	public class RemoveAttendeesCommand
	{
		public int AppointmentId { get; }
		public List<Participant> ParticipantsToDelete { get; }

		public RemoveAttendeesCommand(int appointmentId, List<Participant> participantsToRemove)
		{
			if (participantsToRemove.Count == 0) throw new ArgumentException(nameof(participantsToRemove));

			AppointmentId = appointmentId;
			ParticipantsToDelete = participantsToRemove ?? throw new ArgumentNullException(nameof(participantsToRemove));
		}
	}
}
