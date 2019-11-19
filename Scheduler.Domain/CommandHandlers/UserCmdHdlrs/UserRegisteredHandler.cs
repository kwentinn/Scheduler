using Kledex.Commands;
using Kledex.Domain;
using Scheduler.Domain.Commands.UserCommands;
using Scheduler.Domain.Policies;
using System;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.UserCmdHdlrs
{
	public class RegisterUserHandler : ICommandHandlerAsync<RegisterUser>
	{
		public readonly IRepository<User> _repository;
		private readonly IPolicy<RegisterUser, User> _policy;

		public RegisterUserHandler(IRepository<User> repository, IPolicy<RegisterUser, User> policy)
		{
			_repository = repository;
			_policy = policy;
		}

		public async Task<CommandResponse> HandleAsync(RegisterUser command)
		{
			// création de l'instance
			var user = new User(command.AggregateRootId, command.Firstname, command.Lastname, command.Email, command.TimeZoneCode);

			var policyResult = await _policy.CanExecuteAsync(command, user);
			if (!policyResult.CanExecute)
			{
				throw new ApplicationException($"Cannot register the user. Policy error: {policyResult.Reason}");
			}

			//... et sauvegarde 
			await _repository.SaveAsync(user);

			// on renvoie la liste d'évènements 
			return new CommandResponse
			{
				Events = user.Events,
				Result = user.Id
			};
		}
	}
}
