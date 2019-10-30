using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Domain.Repositories
{
	public interface ICalendarRepository
	{
		Task CreateCalendar(Calendar calendar);
		Calendar GetById(Guid calendarId);
		Task UpdateAsync(Calendar calendar);
		Task SaveAsync();
	}
}
