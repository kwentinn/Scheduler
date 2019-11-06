using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class CreateCalendar : DomainCommand<Calendar>
	{
		public string Title { get; }
		public string TimeZone { get; }

		public CreateCalendar()
		{

		}
		public CreateCalendar(Guid calendarId, string title, string timeZone)
		{
			Id = Guid.NewGuid();
			AggregateRootId = calendarId;
			Title = title;
			TimeZone = timeZone;
		}
	}
}
