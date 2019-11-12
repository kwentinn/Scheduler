using Kledex;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Controllers.ApiCommands;
using System;
using System.Threading.Tasks;

namespace Scheduler.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AppointmentController : ControllerBase
	{
		private readonly IDispatcher _dispatcher;

		public AppointmentController(IDispatcher dispatcher)
		{
			_dispatcher = dispatcher;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAppointmentAsync(PlanAppointment command)
		{
			var domainCommand = new Domain.Commands.AppointmentCommands.PlanNewAppointment
			{
				Id = Guid.NewGuid(),

				AggregateRootId = Guid.NewGuid(),
				CalendarId = command.CalendarId,
				Title = command.Title,
				Description = command.Description,
				UtcStart = command.UtcStart,
				UtcEnd = command.UtcEnd
			};

			var appointmentId = await _dispatcher.SendAsync<Guid>(domainCommand);

			return Ok(new { Id = appointmentId });
		}
	}
}
