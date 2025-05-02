using System.Net.Http.Json;
using System.Text.Json;
using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Interfaces;
using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Responses;
using GitHub.Api.Infrastructure.Repositories.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub
{
    public class GitHubRepository : IGitHubRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GitHubRepository> _logger;
        private readonly IOptions<GitHubOption> _option;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public GitHubRepository(
            HttpClient httpClient,
            ILogger<GitHubRepository> logger,
            IOptions<GitHubOption> option)
        {
            _httpClient = httpClient;
            _logger = logger;
            _option = option;
        }

        public async Task<IEnumerable<GetUsersResponse>> GetUsersAsync(int since, CancellationToken cancellationToken)
        {
            var endpoint = string.Format(_option.Value.GetUsersPath, since);

            try
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHub.Api");

                var response = await _httpClient.GetAsync(endpoint, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("GitHubRepository - GetUsersAsync: error to list GitHub users.");
                    return Enumerable.Empty<GetUsersResponse>();
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<GetUsersResponse>>(_jsonSerializerOptions, cancellationToken);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "GitHubRepository - GetUsersAsync: error to list GitHub users.");
                return Enumerable.Empty<GetUsersResponse>();
            }
        }
    }
}

