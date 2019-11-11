using Kledex;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Scheduler.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CalendarController : ControllerBase
	{
		private readonly IDispatcher _dispatcher;

		public CalendarController(IDispatcher dispatcher)
		{
			_dispatcher = dispatcher;
		}

		[HttpGet]
		public async Task<IActionResult> GetCalendarAsync([FromQuery(Name = "calendarId")]Guid calendarId)
		{
			throw new NotImplementedException("à coder!");
		}

		[HttpPost]
		public async Task<IActionResult> CreateCalendarAsync(ApiCommands.CreateCalendarCommand command)
		{
			var cmd = new Domain.Commands.CalendarCommands.CreateCalendar
			{
				Id = Guid.NewGuid(),
				
				AggregateRootId = Guid.NewGuid(),
				Title = command.Title,
				TimeZone = command.TimeZone
			};

			var calendarId = await _dispatcher.SendAsync<Guid>(cmd);

			return Ok(new { Id = calendarId });
		}
	}
}
