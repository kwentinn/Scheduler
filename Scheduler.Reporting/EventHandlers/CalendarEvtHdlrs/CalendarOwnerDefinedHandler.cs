using Kledex.Events;
using Scheduler.Domain.Events;
using Scheduler.Reporting.Data;
using System.Threading.Tasks;

namespace Scheduler.Reporting.EventHandlers.CalendarEvtHdlrs
{
	public class CalendarOwnerDefinedHandler : IEventHandlerAsync<CalendarOwnerDefined>
	{
		private readonly IReadModelService _readModelService;

		public CalendarOwnerDefinedHandler(IReadModelService readModelService)
		{
			_readModelService = readModelService;
		}

		public async Task HandleAsync(CalendarOwnerDefined @event)
		{
			await _readModelService.AddCalendarOwnerAsync(@event.AggregateRootId, @event.OwnerId);
		}
	}
}
