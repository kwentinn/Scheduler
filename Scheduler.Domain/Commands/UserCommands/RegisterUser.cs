using Kledex.Domain;

namespace Scheduler.Domain.Commands.UserCommands
{
	public class RegisterUser : DomainCommand<User>
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
		public string TimeZoneCode { get; set; }

		public RegisterUser()
		{

		}
	}
}
