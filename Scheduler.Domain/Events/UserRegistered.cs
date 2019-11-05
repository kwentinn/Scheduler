using Kledex.Domain;

namespace Scheduler.Domain.Events
{
	public class UserRegistered : DomainEvent
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
		public string TimeZoneCode { get; set; }
	}
}
