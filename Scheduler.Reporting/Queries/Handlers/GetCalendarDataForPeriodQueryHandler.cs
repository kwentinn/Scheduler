using Kledex.Queries;
using Scheduler.Reporting.Data;
using Scheduler.Reporting.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduler.Reporting.Queries.Handlers
{
	public class GetCalendarDataForPeriodQueryHandler : IQueryHandlerAsync<GetCalendarDataForPeriodQuery, IEnumerable<CalendarEntity>>
	{
		private readonly IReadModelService _readModel;
		public GetCalendarDataForPeriodQueryHandler(IReadModelService readModel)
		{
			_readModel = readModel;
		}

		public async Task<IEnumerable<CalendarEntity>> HandleAsync(GetCalendarDataForPeriodQuery query)
		{
			return await _readModel.GetCalendarDataForPeriodAsync();

		}
	}
}
