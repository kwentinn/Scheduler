using Kledex;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Scheduler.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IDispatcher _dispatcher;

		public UserController(IDispatcher dispatcher)
		{
			_dispatcher = dispatcher;
		}

		[HttpPost]
		public async Task<IActionResult> CreateUserAsync(Scheduler.Controllers.ApiCommands.CreateUserCommand command)
		{
			var cmd = new Domain.Commands.UserCommands.RegisterUser(Guid.NewGuid(), command.Firstname, command.Lastname, command.Email, command.TimeZone);

			var userId = await _dispatcher.SendAsync<Guid>(cmd);

			return Ok(new { Id = userId });
		}
	}
}
