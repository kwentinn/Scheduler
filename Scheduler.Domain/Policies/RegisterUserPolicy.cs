using Scheduler.Domain.Commands.UserCommands;
using Scheduler.Domain.Repositories;
using System.Threading.Tasks;

namespace Scheduler.Domain.Policies
{
	public class RegisterUserPolicy : IPolicy<RegisterUser, User>
	{
		private readonly IUserRepository _userRepository;

		public RegisterUserPolicy(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<PolicyResult> CanExecuteAsync(User aggregateRoot)
		{
			var userExists = _userRepository.DoesUserExistWithEmail(aggregateRoot.Email);
			if (userExists)
			{
				return await Task.FromResult(new PolicyResult
				{
					CanExecute = false,
					Reason = "A user exists with the same e-mail address."
				});
			}

			return await Task.FromResult(new PolicyResult { CanExecute = true });
		}
	}
}
