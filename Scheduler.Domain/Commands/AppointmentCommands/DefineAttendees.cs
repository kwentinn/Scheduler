using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain.Commands.AppointmentCommands
{
	public class DefineAttendees : DomainCommand<Appointment>
	{
		public List<Guid> ParticipantsIdsToAdd { get; }

		public DefineAttendees(Guid appointmentId, List<Guid> participantsIdsToAdd)
		{
			if (participantsIdsToAdd.Count == 0) throw new ArgumentException(nameof(participantsIdsToAdd));

			AggregateRootId = appointmentId;
			ParticipantsIdsToAdd = participantsIdsToAdd ?? throw new ArgumentNullException(nameof(participantsIdsToAdd));
		}
	}
}
