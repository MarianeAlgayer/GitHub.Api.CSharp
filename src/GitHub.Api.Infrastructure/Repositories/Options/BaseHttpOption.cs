namespace GitHub.Api.Infrastructure.Repositories.Options
{
    public class BaseHttpOption
    {
        public string BaseUrl { get; set; }
        public TimeSpan Timeout { get; set; }
    }
}
