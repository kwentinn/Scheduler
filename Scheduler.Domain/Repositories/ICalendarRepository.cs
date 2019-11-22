using System.Threading.Tasks;

namespace Scheduler.Domain.Repositories
{
	public interface ICalendarRepository
	{
		Task<bool> DoesCalendarExistWithNameAsync(string name);
	}
}
