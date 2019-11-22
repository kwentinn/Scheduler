using Microsoft.EntityFrameworkCore;
using Scheduler.Domain.Repositories;
using System.Threading.Tasks;

namespace Scheduler.Reporting.Data.Repositories
{
	public class CalendarRepository : ICalendarRepository
	{
		private readonly SchedulerReadModelDbContext _context;

		public CalendarRepository(SchedulerReadModelDbContext context)
		{
			_context = context;
		}

		public async Task<bool> DoesCalendarExistWithNameAsync(string calendarTitle)
		{
			return await _context.Calendars
				.AnyAsync(c => c.Title == calendarTitle);
		}
	}
}
