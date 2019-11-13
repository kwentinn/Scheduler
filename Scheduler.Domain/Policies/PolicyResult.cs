namespace Scheduler.Domain.Policies
{
	public class PolicyResult
	{
		public bool CanExecute { get; set; }
		public string Reason { get; set; }
	}
}
