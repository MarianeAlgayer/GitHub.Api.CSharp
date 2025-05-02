using GitHub.Api.Application.UseCases.Users.Interfaces;

namespace GitHub.Api.Application.UseCases.Users
{
    public class UsersUseCase : IUsersUseCase
    {
        private readonly IGitHubRepository _gitHubRepository;

        public UsersUseCase(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }

        public async Task<UsersOutput> Handle(UsersInput request, CancellationToken cancellationToken)
        {
            var response = await _gitHubRepository.GetUsersAsync(cancellationToken);

            return new UsersOutput() { Users = response };
        }
    }
}

