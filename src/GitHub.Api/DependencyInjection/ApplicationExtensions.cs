using GitHub.Api.Application.UseCases.Users;
using GitHub.Api.Application.UseCases.Users.Interfaces;
using GitHub.Api.Infrastructure.Repositories.Options;

namespace GitHub.Api.DependencyInjection
{
	public static class ApplicationExtensions
	{
		public static IServiceCollection AddUseCases(this IServiceCollection services)
		{
			services.AddScoped<IUsersUseCase, UsersUseCase>();

			return services;
		}

		public static IServiceCollection AddOptionsConfig(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<GitHubOption>(options =>
				configuration
					.GetSection(GitHubOption.SectionName)
					.Bind(options));

            return services;
        }
    }
}
