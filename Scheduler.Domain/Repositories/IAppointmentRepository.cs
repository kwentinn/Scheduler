using Itenso.TimePeriod;
using System;

namespace Scheduler.Domain.Repositories
{
	public interface IAppointmentRepository
	{
		bool HasAppointmentForPeriod(Guid calendarId, TimeRange utcPeriod);
	}
}
