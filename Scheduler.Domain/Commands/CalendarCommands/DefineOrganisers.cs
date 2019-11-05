using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class DefineOrganisers : DomainCommand<Calendar>
	{
		public List<Guid> OrganisersIds { get; }

		public DefineOrganisers(Guid calendarId, List<Guid> organisersIds)
		{
			OrganisersIds = organisersIds;
			AggregateRootId = calendarId;
		}
	}
}
