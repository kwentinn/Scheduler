using Kledex.Commands;
using System.Threading.Tasks;

namespace Scheduler.Domain.Policies
{
	public interface IPolicy<ICommand>
		where ICommand : Kledex.Commands.ICommand
	{
		PolicyResult CanExecute(ICommand command);
		Task<PolicyResult> CanExecuteAsync(ICommand command);
	}
}
