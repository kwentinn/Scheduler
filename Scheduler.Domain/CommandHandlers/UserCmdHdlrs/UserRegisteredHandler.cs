using Kledex.Commands;
using Kledex.Domain;
using Scheduler.Domain.Commands.UserCommands;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.UserCmdHdlrs
{
	public class UserRegisteredHandler : ICommandHandlerAsync<RegisterUser>
	{
		public readonly IRepository<User> _repository;

		public UserRegisteredHandler(IRepository<User> repository)
		{
			_repository = repository;
		}

		public async Task<CommandResponse> HandleAsync(RegisterUser command)
		{
			// création de l'instance
			var user = new User(command.AggregateRootId, command.Firstname, command.Lastname, command.Email, command.TimeZoneCode);

			//... et sauvegarde (sans event sourcing)
			await _repository.SaveAsync(user);

			// on renvoie une liste d'évènements
			return new CommandResponse
			{
				Events = user.Events
			};
		}
	}
}
