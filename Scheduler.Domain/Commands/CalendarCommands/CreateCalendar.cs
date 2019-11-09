using Kledex.Domain;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class CreateCalendar : DomainCommand<Calendar>
	{
		public string Title { get; set; }
		public string TimeZone { get; set; }
	}
}
