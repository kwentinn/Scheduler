using Kledex.Events;
using Scheduler.Domain.Events;
using Scheduler.Reporting.Data;
using System.Threading.Tasks;

namespace Scheduler.Reporting.EventHandlers.UserEvtHdlrs
{
	public class UserRegisteredHandler : IEventHandlerAsync<UserRegistered>
	{
		private readonly IReadModelService _readModelService;

		public UserRegisteredHandler(IReadModelService readModelService)
		{
			_readModelService = readModelService;
		}

		public async Task HandleAsync(UserRegistered @event)
		{
			await _readModelService.CreateUserAsync(@event.Id, @event.Firstname, @event.Lastname, @event.Email, @event.TimeZone);
		}
	}
}
