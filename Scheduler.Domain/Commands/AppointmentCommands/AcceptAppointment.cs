using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.AppointmentCommands
{
	public class AcceptAppointment : DomainCommand<Appointment>
	{
		public Guid ParticipantId { get; private set; }

		public AcceptAppointment(Guid appointmentId, Guid participantId)
		{
			Id = Guid.NewGuid();

			AggregateRootId = appointmentId;
			ParticipantId = participantId;
		}
	}
}
