using Kledex.Domain;
using Scheduler.Domain.Events;
using Scheduler.Domain.Repositories;
using System;
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
			await Task.CompletedTask;

			// comment savoir si on peut effectivement archiver ce calendrier ?
			// la règle doit se trouver dans le code, dans l'objet métier!!
			Calendar calendar = _calendarRepository.GetById(command.AggregateRootId);
			if (calendar == null)
				throw new ApplicationException("Calendar not found");

			calendar.Archive();

			// on met à jour et on sauvegarde
			await _calendarRepository.UpdateAsync(calendar);
			await _calendarRepository.SaveAsync();

			return new List<IDomainEvent>
			{
				new CalendarArchivedEvent()
			};
		}
	}
}
