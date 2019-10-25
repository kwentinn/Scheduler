using Kledex.Domain;
using Scheduler.Domain.Events;
using Scheduler.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduler.Domain.Commands.Handlers
{
	public class ArchiveCalendarHandler : IDomainCommandHandlerAsync<ArchiveCalendarCommand>
	{
		private readonly ICalendarRepository _calendarRepository;

		public ArchiveCalendarHandler(ICalendarRepository calendarRepository)
		{
			_calendarRepository = calendarRepository;
		}

		public async Task<IEnumerable<IDomainEvent>> HandleAsync(ArchiveCalendarCommand command)
		{
			await _calendarRepository.ArchiveCalendar(command.AggregateRootId);

			return new List<IDomainEvent>
			{
				new CalendarArchivedEvent()
			};
		}
	}
}
