using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain.Commands.AppointmentCommands
{
	public class RemoveAttendees : DomainCommand<Appointment>
	{
		public List<Guid> ParticipantsIdsToDelete { get; }

		public RemoveAttendees(Guid appointmentId, List<Guid> participantsIdsToDelete)
		{
			if (participantsIdsToDelete.Count == 0) throw new ArgumentException(nameof(participantsIdsToDelete));

			AggregateRootId = appointmentId;
			ParticipantsIdsToDelete = participantsIdsToDelete ?? throw new ArgumentNullException(nameof(participantsIdsToDelete));
		}
	}
}
