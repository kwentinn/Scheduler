﻿using Kledex.Events;
using Scheduler.Domain.Events;
using Scheduler.Reporting.Data;
using System.Threading.Tasks;

namespace Scheduler.Reporting.EventHandlers.CalendarEvtHdlrs
{
	public class NewCalendarCreatedHandler : IEventHandlerAsync<NewCalendarDefinedEvent>
	{
		private readonly IReadModelService _readModelService;

		public NewCalendarCreatedHandler(IReadModelService readModelService)
		{
			_readModelService = readModelService;
		}

		public async Task HandleAsync(NewCalendarDefinedEvent @event)
		{
			await _readModelService.CreateCalendarAsync(@event.AggregateRootId, @event.Title);
		}
	}
}
