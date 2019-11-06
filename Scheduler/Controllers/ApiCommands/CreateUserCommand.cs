namespace Scheduler.Controllers.ApiCommands
{
	public class CreateUserCommand
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
		public string TimeZone { get; set; }
	}
}