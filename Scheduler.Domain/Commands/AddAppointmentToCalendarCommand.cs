using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands
{
	public class AddAppointmentToCalendarCommand : DomainCommand<Calendar>
	{
		public string AppointmentTitle { get; set; }
		public DateTime AppointmentStartUtc { get; set; }
		public DateTime AppointmentEndUtc { get; set; }
	}
}
