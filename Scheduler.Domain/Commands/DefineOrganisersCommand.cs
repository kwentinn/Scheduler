using Kledex.Domain;
using System;
using System.Collections.Generic;

namespace Scheduler.Domain.Commands
{
	public class DefineOrganisersCommand : DomainCommand<Calendar>
	{
		public List<Organiser> Organisers { get; }
		public DefineOrganisersCommand(List<Organiser> organisers)
		{
			if (organisers.Count == 0) throw new ArgumentException(nameof(organisers));
			Organisers = organisers ?? throw new ArgumentNullException(nameof(organisers));
		}
	}
}
