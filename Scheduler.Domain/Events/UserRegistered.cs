using Kledex.Domain;
using System;

namespace Scheduler.Domain.Events
{
	public class UserRegistered : DomainEvent
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
		public string TimeZone { get; set; }
	}
}
