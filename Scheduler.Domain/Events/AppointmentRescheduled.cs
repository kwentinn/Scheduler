using Itenso.TimePeriod;
using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class AppointmentRescheduled : DomainEvent
	{
		public TimeRange NewUtcPeriod { get; set; }
	}
}
