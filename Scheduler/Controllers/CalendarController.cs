using Kledex;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Scheduler.Web.Controllers
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

		[HttpPost]
		public async Task<IActionResult> CreateCalendarAsync(Scheduler.Controllers.ApiCommands.CreateCalendarCommand command)
		{
			var cmd = new Domain.Commands.CalendarCommands.CreateCalendar(new Guid(), command.Title, command.TimeZoneCode);
			var calendarId = await _dispatcher.SendAsync<Guid>(cmd);
			return Ok(new { Id = calendarId });
		}
	}
}
