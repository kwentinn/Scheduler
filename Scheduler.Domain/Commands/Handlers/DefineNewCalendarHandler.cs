using Kledex.Domain;
using Scheduler.Domain.Events;
using Scheduler.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduler.Domain.Commands.Handlers
{
	public class DefineNewCalendarHandler : IDomainCommandHandlerAsync<DefineNewCalendarCommand>
	{
		private readonly ICalendarRepository _calendarRepository;

		public DefineNewCalendarHandler(ICalendarRepository calendarRepository)
		{
			_calendarRepository = calendarRepository;
		}


		public async Task<IEnumerable<IDomainEvent>> HandleAsync(DefineNewCalendarCommand command)
		{
			// création de l'instance
			var calendar = new Calendar(command.AggregateRootId, command.CalendarName);

			//... et sauvegarde (sans event sourcing)
			await _calendarRepository.CreateCalendar(calendar);

			// on renvoie une liste d'évènements
			return new List<IDomainEvent>
			{
				new NewCalendarDefinedEvent(calendar.Id, calendar.Name)
			};
		}
	}
}
