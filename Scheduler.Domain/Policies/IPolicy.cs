using System.Threading.Tasks;

namespace Scheduler.Domain.Policies
{
	public interface IPolicy<IDomainCommand, IAggregateRoot>
		where IDomainCommand : Kledex.Domain.IDomainCommand
		where IAggregateRoot : Kledex.Domain.IAggregateRoot
	{
		Task<PolicyResult> CanExecuteAsync(IDomainCommand command, IAggregateRoot aggregateRoot);
	}
}
