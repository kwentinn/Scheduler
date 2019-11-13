using Scheduler.Domain.Commands.AppointmentCommands;

namespace Scheduler.Domain.Policies
{
	public interface IPolicy<IDomainCommand, IAggregateRoot>
		where IDomainCommand : Kledex.Domain.IDomainCommand
		where IAggregateRoot : Kledex.Domain.IAggregateRoot
	{
		bool CanExecute(IAggregateRoot aggregateRoot);
	}
}
