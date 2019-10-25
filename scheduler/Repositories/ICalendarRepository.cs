using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Domain.Repositories
{
	public interface ICalendarRepository
	{
		Task CreateCalendar(Calendar calendar);
		Task ArchiveCalendar(Guid aggregateRootId);
	}
}
