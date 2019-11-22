using Kledex.Commands;
using Scheduler.Domain.Commands.UserCommands;
using System.Threading.Tasks;

namespace Scheduler.Domain.CommandHandlers.UserCmdHdlrs
{
	public class RegisterUserHandler : ICommandHandlerAsync<RegisterUser>
	{
		public async Task<CommandResponse> HandleAsync(RegisterUser command)
		{
			// création de l'instance
			var user = new User(command.AggregateRootId, command.Firstname, command.Lastname, command.Email, command.TimeZoneCode);

			// on renvoie la liste d'évènements 
			return await Task.FromResult(new CommandResponse
			{
				Events = user.Events,
				Result = user.Id
			});
		}
	}
}
