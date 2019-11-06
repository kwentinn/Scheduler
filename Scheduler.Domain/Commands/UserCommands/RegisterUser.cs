using Kledex.Domain;
using System;

namespace Scheduler.Domain.Commands.UserCommands
{
	public class RegisterUser : DomainCommand<User>
	{
		public string Firstname { get; }
		public string Lastname { get; }
		public string Email { get; }
		public string TimeZoneCode { get; }

		public RegisterUser() { }
		public RegisterUser(Guid userId, string firstname, string lastname, string email, string timeZoneCode)
		{
			Id = Guid.NewGuid();

			AggregateRootId = userId;
			Firstname = firstname;
			Lastname = lastname;
			Email = email;
			TimeZoneCode = timeZoneCode;
		}
	}
}
