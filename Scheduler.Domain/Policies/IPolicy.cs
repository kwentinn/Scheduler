using Scheduler.Domain.Commands.AppointmentCommands;

namespace Scheduler.Domain.Policies
{
	public interface IPolicy<IDomainCommand, IAggregateRoot>
		where IDomainCommand : Kledex.Domain.IDomainCommand
		where IAggregateRoot : Kledex.Domain.IAggregateRoot
	{
		PolicyResult CanExecute(IAggregateRoot aggregateRoot);
	}
}
