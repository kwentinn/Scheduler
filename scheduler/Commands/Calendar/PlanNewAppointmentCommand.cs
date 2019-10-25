using System;

namespace Scheduler.Commands.Calendar
{
	public class PlanNewAppointmentCommand
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
