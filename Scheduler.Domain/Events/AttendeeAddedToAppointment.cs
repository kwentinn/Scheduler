using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class AttendeeAddedToAppointment : DomainEvent
	{
		public Guid AppointmentId { get; set; }
		public Guid AttendeeUserId { get; set; }
	}
}
