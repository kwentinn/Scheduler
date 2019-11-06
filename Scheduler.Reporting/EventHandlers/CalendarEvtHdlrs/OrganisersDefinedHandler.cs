using Kledex.Events;
using Scheduler.Domain.Events;
using Scheduler.Reporting.Data;
using System.Threading.Tasks;

namespace Scheduler.Reporting.EventHandlers.CalendarEvtHdlrs
{
	public class OrganisersDefinedHandler : IEventHandlerAsync<OrganisersDefined>
	{
		private readonly IReadModelService _readModelService;

		public OrganisersDefinedHandler(IReadModelService readModelService)
		{
			_readModelService = readModelService;
		}

		public async Task HandleAsync(OrganisersDefined @event)
		{
			await _readModelService.AddOrganisersToCalendarAsync(@event.AggregateRootId, @event.Organisers);
		}
	}
}
