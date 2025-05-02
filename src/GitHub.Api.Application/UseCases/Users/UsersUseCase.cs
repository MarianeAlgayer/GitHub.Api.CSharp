using GitHub.Api.Application.UseCases.Users.Interfaces;
using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Interfaces;
using GitHub.Api.Infrastructure.Repositories.Options;
using Microsoft.Extensions.Options;

namespace GitHub.Api.Application.UseCases.Users
{
    public class UsersUseCase : IUsersUseCase
    {
        private readonly IGitHubRepository _gitHubRepository;
        private readonly IOptions<GitHubOption> _option;

        public UsersUseCase(
            IGitHubRepository gitHubRepository,
            IOptions<GitHubOption> option)
        {
            _gitHubRepository = gitHubRepository;
            _option = option;
        }

        public async Task<UsersOutput> Handle(UsersInput request, CancellationToken cancellationToken)
        {
            var response = new UsersOutput();

            var users = await _gitHubRepository.GetUsersAsync(request.Since, cancellationToken);

            if (!users.Any()) return response;

            var endpoint = _option.Value.BaseUrl + _option.Value.GetUsersPath;

            response.Users = users;
            response.Next = string.Format(endpoint, users.LastOrDefault().Id);

            return response;
        }
    }
}
