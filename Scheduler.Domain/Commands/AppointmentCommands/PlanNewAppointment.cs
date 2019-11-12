﻿using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.AppointmentCommands
{
	public class PlanNewAppointment : DomainCommand<Appointment>
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime UtcStart { get; set; }
		public DateTime UtcEnd { get; set; }
		public Guid CalendarId { get; set; }
	}
}
