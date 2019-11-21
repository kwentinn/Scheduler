﻿using Kledex;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Reporting.Data.Entities;
using Scheduler.Reporting.Queries;
using System;
using System.Collections.Generic;
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

		[HttpGet]
		public async Task<IActionResult> GetUsersAsync()
		{
			var data = await _dispatcher.GetResultAsync<IEnumerable<UserEntity>>(new GetRecentRegisteredUsersQuery());
			return Ok(data);
		}

		[HttpPost]
		public async Task<IActionResult> CreateUserAsync(ApiCommands.CreateUserCommand command)
		{
			var cmd = new Domain.Commands.UserCommands.RegisterUser
			{
				Id = Guid.NewGuid(),
				AggregateRootId = Guid.NewGuid(),
				Firstname = command.Firstname,
				Lastname = command.Lastname,
				Email = command.Email,
				TimeZoneCode = command.TimeZone,

				Validate = true
			};

			var userId = await _dispatcher.SendAsync<Guid>(cmd);

			return Ok(new { Id = userId });
		}
	}
}
