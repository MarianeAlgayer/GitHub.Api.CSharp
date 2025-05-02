using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Responses;

namespace GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Interfaces
{
	public interface IGitHubRepository
	{
		Task<IEnumerable<GetUsersResponse>> GetUsersAsync(int since, CancellationToken cancellationToken);
	}
}

