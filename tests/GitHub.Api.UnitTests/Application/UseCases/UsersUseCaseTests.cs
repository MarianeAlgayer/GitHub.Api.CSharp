using FizzWare.NBuilder;
using FluentAssertions;
using GitHub.Api.Application.UseCases.Users;
using GitHub.Api.Application.UseCases.Users.Interfaces;
using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Interfaces;
using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Responses;
using GitHub.Api.Infrastructure.Repositories.Options;
using Microsoft.Extensions.Options;
using NSubstitute;
using Xunit;

namespace GitHub.Api.UnitTests.Application.UseCases
{
    public class UsersUseCaseTests
	{
		private readonly IGitHubRepository _gitHubRepository;
		private readonly IOptions<GitHubOption> _option;
        private readonly IUsersUseCase _usersUseCase;

        public UsersUseCaseTests()
        {
            _gitHubRepository = Substitute.For<IGitHubRepository>();
            _option = Substitute.For<IOptions<GitHubOption>>();
            _option.Value.Returns(new GitHubOption()
            {
                BaseUrl = "url",
                GetUsersPath = "/path?since={0}"
            });
            _usersUseCase = new UsersUseCase(_gitHubRepository, _option);
        }

        [Theory(DisplayName = "UseCase - should return a list of users")]
        [InlineData(0, 46)]
        public async Task ShouldListGitHubUsers(int since, int lastId)
        {
            var input = new UsersInput() { Since = since };
            var output = Builder<GetUsersResponse>
                .CreateListOfSize(5)
                .TheLast(1)
                .With(u => u.Id = lastId)
                .Build();

            _gitHubRepository.GetUsersAsync(Arg.Any<int>(), Arg.Any<CancellationToken>()).Returns(output);

            var result = await _usersUseCase.Handle(input, CancellationToken.None);

            result.Users.Should().NotBeNullOrEmpty();
            result.Next.Should().Contain(lastId.ToString());
        }
    }
}
