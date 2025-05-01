using Microsoft.AspNetCore.Mvc;

namespace TrackFetch.Api.DependencyInjection
{
	public static class VersioningExtension
	{
		public static IServiceCollection AddVersioning(this IServiceCollection services)
		{
			services.AddApiVersioning(c =>
            {
                c.DefaultApiVersion = new ApiVersion(1, 0);
                c.ReportApiVersions = true;
                c.AssumeDefaultVersionWhenUnspecified = true;          
            });

			services.AddVersionedApiExplorer(c =>
			{
				c.GroupNameFormat = "'v'VVV";
				c.SubstituteApiVersionInUrl = true;
			});

			return services;
		}
	}
}
