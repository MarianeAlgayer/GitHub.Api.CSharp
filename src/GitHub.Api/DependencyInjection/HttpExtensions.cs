
using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub;
using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Interfaces;
using GitHub.Api.Infrastructure.Repositories.Options;

namespace GitHub.Api.DependencyInjection
{
    public static class HttpExtensions
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var gitHubConfig = configuration.GetSection(GitHubOption.SectionName).Get<GitHubOption>();

            services.AddHttpClient<IGitHubRepository, GitHubRepository>(c =>
            {
                c.BaseAddress = new Uri(gitHubConfig.BaseUrl);
                c.Timeout = gitHubConfig.Timeout;
            });

            return services;
        }
    }
}
