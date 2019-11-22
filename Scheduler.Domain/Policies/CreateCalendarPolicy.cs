using Scheduler.Domain.Commands.CalendarCommands;
using Scheduler.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Scheduler.Domain.Policies
{
	public class CreateCalendarPolicy : IPolicy<CreateCalendar>
	{
		private readonly ICalendarRepository _calendarRepository;

		public CreateCalendarPolicy(ICalendarRepository calendarRepository)
		{
			_calendarRepository = calendarRepository;
		}
		public PolicyResult CanExecute(CreateCalendar command)
		{
			throw new NotImplementedException();
		}
		public async Task<PolicyResult> CanExecuteAsync(CreateCalendar command)
		{
			var exists = await _calendarRepository.DoesCalendarExistWithNameAsync(command.Title);
			return new PolicyResult
			{
				CanExecute = !exists,
				Reason = exists ? "A calendar with the same title already exists" : null
			};
		}
	}
}
