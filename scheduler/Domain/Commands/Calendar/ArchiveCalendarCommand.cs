namespace Scheduler.Domain.Commands.Calendar
{
	public class ArchiveCalendarCommand
	{
		public int CalendarId { get; }

		public ArchiveCalendarCommand(int calendarId)
		{
			CalendarId = calendarId;
		}
	}
}
