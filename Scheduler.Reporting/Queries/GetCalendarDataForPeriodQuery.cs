using Kledex.Queries;
using Scheduler.Reporting.Data.Entities;
using System;
using System.Collections.Generic;

namespace Scheduler.Reporting.Queries
{
	public class GetCalendarDataForPeriodQuery : IQuery<IEnumerable<CalendarEntity>>
	{
		public DateTime utcStart { get; set; }
		public DateTime utcEnd { get; set; }
	}
}
