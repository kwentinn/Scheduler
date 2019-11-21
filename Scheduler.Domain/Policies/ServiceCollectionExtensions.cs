using Kledex.Extensions;
using Kledex.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Scheduler.Domain.Policies
{
	public static class ServiceCollectionExtensions
	{
		public static IKledexServiceBuilder AddPolicyValidationProvider(this IKledexServiceBuilder builder)
		{
			builder.Services.AddScoped<IValidationProvider, PolicyValidationProvider>();

			return builder;
		}
	}
}
