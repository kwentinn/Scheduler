using Itenso.TimePeriod;
using Scheduler.Domain.Repositories;
using System;
using System.Linq;

namespace Scheduler.Reporting.Data.Repositories
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly SchedulerReadModelDbContext _context;

		public AppointmentRepository(SchedulerReadModelDbContext context)
		{
			_context = context;
		}

		public bool HasAppointmentForPeriod(Guid calendarId, TimeRange utcPeriod)
		{
			return _context.Appointments
				.Any(a => a.CalendarId == calendarId && utcPeriod.End > a.UtcStart && utcPeriod.Start < a.UtcEnd);
		}
	}
}
