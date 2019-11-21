using Kledex.Commands;
using Kledex.Dependencies;
using Kledex.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.Domain.Policies
{
	public class PolicyValidationProvider : IValidationProvider
	{
		private readonly IHandlerResolver _handlerResolver;

		public PolicyValidationProvider(IHandlerResolver handlerResolver)
		{
			_handlerResolver = handlerResolver;
		}

		public async Task<ValidationResponse> ValidateAsync(ICommand command)
		{
			var validator = _handlerResolver.ResolveHandler(command, typeof(IPolicy<>));

			var validatorType = validator.GetType();
			var cmdType = command.GetType();

			var validateMethod = validator.GetType().GetMethod("CanExecuteAsync", new[] { command.GetType() });
			var policyResult = await (Task<PolicyResult>)validateMethod.Invoke(validator, new object[] { command });

			return BuildValidationResponse(policyResult);
		}

		public ValidationResponse Validate(ICommand command)
		{
			var validator = _handlerResolver.ResolveHandler(command, typeof(IPolicy<>));
			var validateMethod = validator.GetType().GetMethod("Validate", new[] { command.GetType() });
			var policyResult = (PolicyResult)validateMethod.Invoke(validator, new object[] { command });

			return BuildValidationResponse(policyResult);
		}

		private static ValidationResponse BuildValidationResponse(PolicyResult policyResult)
		{
			var errors = new List<ValidationError>();
			if (!policyResult.CanExecute)
			{
				errors.Add(new ValidationError { ErrorMessage = policyResult.Reason });
			}
			return new ValidationResponse { Errors = errors };
		}
	}
}
