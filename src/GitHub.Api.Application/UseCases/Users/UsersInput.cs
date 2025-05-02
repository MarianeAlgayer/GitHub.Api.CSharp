using MediatR;

namespace GitHub.Api.Application.UseCases.Users
{
    public class UsersInput : IRequest<UsersOutput>
    {
        public int Since { get; set; }
    }
}
