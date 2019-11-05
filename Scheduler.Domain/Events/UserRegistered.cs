using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class UserRegistered : DomainEvent
	{
		public string Firstname { get; }
		public string Lastname { get; }
		public string Email { get; }
		public string TimeZoneCode { get; }

		public UserRegistered(Guid userId, string firstname, string lastname, string email, string timeZoneCode)
		{
			AggregateRootId = userId;
			Firstname = firstname;
			Lastname = lastname;
			Email = email;
			TimeZoneCode = timeZoneCode;
		}
	}
}
