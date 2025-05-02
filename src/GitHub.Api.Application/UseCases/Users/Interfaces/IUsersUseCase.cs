using MediatR;

namespace GitHub.Api.Application.UseCases.Users.Interfaces
{
	public interface IUsersUseCase : IRequestHandler<UsersInput, UsersOutput> { }
}
