using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Interfaces;
using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Responses;
using GitHub.Api.Infrastructure.Repositories.Options;

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

        public async Task<IEnumerable<GetUsersResponse>> GetUsersAsync(CancellationToken cancellationToken)
        {
            var endpoint = _option.Value.GetUsersPath;

            try
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHub.Api");

                var response = await _httpClient.GetAsync(endpoint, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("");
                    return Enumerable.Empty<GetUsersResponse>();
                }

                return await response.Content.ReadFromJsonAsync<IEnumerable<GetUsersResponse>>(_jsonSerializerOptions, cancellationToken);
            }
            catch(Exception e)
            {
                _logger.LogError("");
                return Enumerable.Empty<GetUsersResponse>();
            }
        }
    }
}

