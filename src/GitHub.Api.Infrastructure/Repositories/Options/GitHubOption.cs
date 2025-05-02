namespace GitHub.Api.Infrastructure.Repositories.Options
{
	public class GitHubOption : BaseHttpOption
	{
		public const string SectionName = "ExternalServices:GitHub";

        public string GetUsersPath { get; set; }
	}
}
