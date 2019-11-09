using System.Collections.Generic;
using System.Threading.Tasks;
using Kledex.Queries;
using Scheduler.Reporting.Data;
using Scheduler.Reporting.Data.Entities;

namespace Scheduler.Reporting.Queries.Handlers
{
	public class GetRecentRegisteredUsersQueryHandler : IQueryHandlerAsync<GetRecentRegisteredUsersQuery, IEnumerable<UserEntity>>
	{
		private readonly IReadModelService _readModel;

		public GetRecentRegisteredUsersQueryHandler(IReadModelService readModel)
		{
			_readModel = readModel;
		}

		public async Task<IEnumerable<UserEntity>> HandleAsync(GetRecentRegisteredUsersQuery query)
		{
			return await _readModel.GetRecentUsersAsync();
		}
	}
}
