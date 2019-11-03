using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands
{
	public class PlanNewAppointmentCommand : DomainCommand<Calendar>
	{
		public int CalendarId { get; }
		public DateTime UtcStart { get; }
		public DateTime UtcEnd { get; }
		public string Title { get; }

		public PlanNewAppointmentCommand(int calendarId, DateTime utcStart, DateTime utcEnd, string title)
		{
			CalendarId = calendarId;
			UtcStart = utcStart;
			UtcEnd = utcEnd;
			Title = title;
		}
	}
}
