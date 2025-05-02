using GitHub.Api.Infrastructure.Repositories.ExternalServices.GitHub.Responses;

namespace GitHub.Api.Application.UseCases.Users
{
    public class UsersOutput
	{
		public IEnumerable<GetUsersResponse> Users { get; set; }
		public string Next { get; set; }
	}
}
