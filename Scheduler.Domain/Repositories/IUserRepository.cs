namespace Scheduler.Domain.Repositories
{
	public interface IUserRepository
	{
		bool DoesUserExistWithEmail(string email);
	}
}
