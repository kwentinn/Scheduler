using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scheduler.Domain;

namespace Scheduler.Reporting.Data
{
	public interface IReadModelService
	{
		Task CreateCalendarAsync(Guid aggregateRootId, string name, string timezone);
		Task AddOrganisersToCalendarAsync(Guid aggregateRootId, List<User> organisers);
	}
	public class ReadModelService : IReadModelService
	{
		private readonly SchedulerReadModelDbContext _context;

		public ReadModelService(SchedulerReadModelDbContext context)
		{
			_context = context;
		}

		public async Task AddOrganisersToCalendarAsync(Guid aggregateRootId, List<User> organisers)
		{
			var calendar = await _context.Calendars.FindAsync(aggregateRootId);
			if (calendar == null)
			{
				throw new ReadModelException($"Cannot find calendar with id {aggregateRootId}");
			}
			var users = await _context.Users.FindAsync(organisers.Select(o => o.Id).ToList());
			//calendar.Organisers =
		}

		public async Task CreateCalendarAsync(Guid aggregateRootId, string title, string timezone)
		{
			_context.Calendars.Add(new Entities.CalendarEntity
			{
				Id = aggregateRootId,
				Title = title,
				TimeZoneCode = timezone,
				IsArchived = false
			});

			await _context.SaveChangesAsync();
		}
	}
}
