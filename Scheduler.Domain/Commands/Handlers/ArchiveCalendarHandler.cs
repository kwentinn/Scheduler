using Kledex.Commands;
using Kledex.Domain;
using System;
using System.Threading.Tasks;

namespace Scheduler.Domain.Commands.Handlers
{
	public class ArchiveCalendarHandler : ICommandHandlerAsync<ArchiveCalendarCommand>
	{
		private readonly IRepository<Calendar> _calendarRepository;

		public ArchiveCalendarHandler(IRepository<Calendar> calendarRepository)
		{
			_calendarRepository = calendarRepository;
		}

		public async Task<CommandResponse> HandleAsync(ArchiveCalendarCommand command)
		{
			// comment savoir si on peut effectivement archiver ce calendrier ?
			// la règle doit se trouver dans le code, dans l'objet métier!!
			// il faut donc le récupérer ici (par son id).
			Calendar calendar = _calendarRepository.GetById(command.AggregateRootId);
			if (calendar == null)
				throw new ApplicationException("Calendar not found");

			calendar.Archive();

			// on met à jour et on sauvegarde
			await _calendarRepository.SaveAsync(calendar);

			return new CommandResponse
			{
				Events = calendar.Events
			};
		}
	}
}
