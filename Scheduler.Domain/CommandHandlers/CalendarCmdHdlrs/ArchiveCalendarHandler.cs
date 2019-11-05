using Kledex.Commands;
using Kledex.Domain;
using Scheduler.Domain.Commands.CalendarCommands;
using System;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.CalendarCmdHdlrs
{
	public class ArchiveCalendarHandler : ICommandHandlerAsync<ArchiveCalendar>
	{
		private readonly IRepository<Calendar> _repository;

		public ArchiveCalendarHandler(IRepository<Calendar> calendarRepository)
		{
			_repository = calendarRepository;
		}

		public async Task<CommandResponse> HandleAsync(ArchiveCalendar command)
		{
			// comment savoir si on peut effectivement archiver ce calendrier ?
			// la règle doit se trouver dans le code, dans l'objet métier!!
			// il faut donc le récupérer ici (par son id).
			Calendar calendar = _repository.GetById(command.AggregateRootId);
			if (calendar == null)
				throw new ApplicationException("Calendar not found");

			// on exécute la méthode contenant le code métier
			calendar.Archive();

			// on met à jour et on sauvegarde
			await _repository.SaveAsync(calendar);

			return new CommandResponse
			{
				Events = calendar.Events
			};
		}
	}
}
