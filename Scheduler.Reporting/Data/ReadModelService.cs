using System;
using System.Threading.Tasks;

namespace Scheduler.Reporting.Data
{
	public interface IReadModelService
	{
		Task CreateCalendarAsync(Guid aggregateRootId, string name);
	}
	public class ReadModelService : IReadModelService
	{
		private readonly SchedulerReadModelDbContext _context;

		public ReadModelService(SchedulerReadModelDbContext context)
		{
			_context = context;
		}
		public async Task CreateCalendarAsync(Guid aggregateRootId, string title)
		{
			_context.Calendars.Add(new Entities.CalendarEntity
			{
				Id = aggregateRootId,
				Title = title,
				IsArchived = false
			});
			await _context.SaveChangesAsync();
		}
	}
}
