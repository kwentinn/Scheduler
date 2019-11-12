using Kledex.Events;
using Scheduler.Domain.Events;
using Scheduler.Reporting.Data;
using Scheduler.Reporting.Data.Entities;
using System.Threading.Tasks;

namespace Scheduler.Reporting.EventHandlers
{
	public class NewAppointmentPlannedHandler : IEventHandlerAsync<NewAppointmentPlanned>
	{
		private readonly SchedulerReadModelDbContext _context;

		public NewAppointmentPlannedHandler(SchedulerReadModelDbContext context)
		{
			_context = context;
		}

		public async Task HandleAsync(NewAppointmentPlanned @event)
		{
			_context.Appointments.Add(new AppointmentEntity
			{
				Id = @event.AggregateRootId,
				CalendarId = @event.CalendarId,
				Title = @event.Title,
				Description = @event.Description,
				UtcStart = @event.Start,
				UtcEnd = @event.End,
			});

			await _context.SaveChangesAsync();
		}
	}
}
