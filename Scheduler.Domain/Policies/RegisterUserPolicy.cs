using Scheduler.Domain.Commands.UserCommands;
using Scheduler.Domain.Repositories;
using System.Threading.Tasks;

namespace Scheduler.Domain.Policies
{
	public class RegisterUserPolicy : IPolicy<RegisterUser>
	{
		private readonly IUserRepository _userRepository;

		public RegisterUserPolicy(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<PolicyResult> CanExecuteAsync(RegisterUser command)
		{
			var userExists = _userRepository.DoesUserExistWithEmail(command.Email);
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

		public PolicyResult CanExecute(RegisterUser command)
		{
			throw new System.NotImplementedException();
		}
	}
}
