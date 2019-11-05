using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain.Commands.CalendarCommands
{
	public class DefineOrganisersCommand : DomainCommand<Calendar>
	{
		public List<Guid> OrganisersIds { get; }
		public DefineOrganisersCommand(Guid calendarId, List<Guid> organisersIds)
		{
			if (calendarId == Guid.NewGuid()) throw new ArgumentException(nameof(calendarId));
			if (organisersIds.Count == 0) throw new ArgumentException(nameof(organisersIds));

			OrganisersIds = organisersIds ?? throw new ArgumentNullException(nameof(organisersIds));
			AggregateRootId = calendarId;
		}
	}
}
