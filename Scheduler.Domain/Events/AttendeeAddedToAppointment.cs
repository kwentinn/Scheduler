using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class AttendeeAddedToAppointment : DomainEvent
	{
		public Guid AppointmentId { get; }
		public Guid AttendeeUserId { get; }

		public AttendeeAddedToAppointment(Guid appointmentId, Guid attendeeUserId)
		{
			AppointmentId = appointmentId;
			AttendeeUserId = attendeeUserId;
		}
	}
}
