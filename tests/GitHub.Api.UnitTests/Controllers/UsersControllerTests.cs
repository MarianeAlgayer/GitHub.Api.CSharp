using FizzWare.NBuilder;
using FluentAssertions;
using GitHub.Api.Application.UseCases.Users;
using GitHub.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace GitHub.Api.UnitTests.Controllers
{
    public class UserControllerTests
    {
        private readonly IMediator _mediator;
        private readonly UsersController _userController;

        public UserControllerTests()
        {
            _mediator = Substitute.For<IMediator>();
            _userController = new UsersController(_mediator);
        }

        [Theory(DisplayName = "Controller - users endpoint should return OK")]
        [InlineData(46)]
        public async Task ShouldListGitHubUsers(int since)
        {
            var input = new UsersInput() { Since = since };
            var output = Builder<UsersOutput>.CreateNew().Build();

            _mediator.Send(input, Arg.Any<CancellationToken>()).Returns(output);

            var result = await _userController.GetUsersAsync(since, CancellationToken.None);

            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;

            okResult.StatusCode.Should().Be(200);
        }
    }
}

