using Kledex.Events;
using Scheduler.Domain.Events;
using Scheduler.Reporting.Data;
using System.Threading.Tasks;

namespace Scheduler.Reporting.EventHandlers
{
	public class AppointmentRescheduledHandler : IEventHandlerAsync<AppointmentRescheduled>
	{
		private readonly SchedulerReadModelDbContext _context;

		public AppointmentRescheduledHandler(SchedulerReadModelDbContext context)
		{
			_context = context;
		}

		public async Task HandleAsync(AppointmentRescheduled @event)
		{
			var appointment = await _context.Appointments.FindAsync(@event.AggregateRootId);

			appointment.UtcStart = @event.NewUtcPeriod.Start;
			appointment.UtcEnd = @event.NewUtcPeriod.End;

			await _context.SaveChangesAsync();
		}
	}
}
