using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CalendarController
	{

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			// query
			throw new NotImplementedException("pas encore codé!!!!");
		}
	}
}
