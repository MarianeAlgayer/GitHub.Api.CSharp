namespace GitHub.Api.DependencyInjection
{
    public static class MediatorExtension
    {
        public static IServiceCollection AddMediatorToUseCases(this IServiceCollection services, string partOfAssemblyName = "Application")
        {
            services.AddMediatR(delegate (MediatRServiceConfiguration cfg)
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name.Contains(partOfAssemblyName)));
            });

            return services;
        }
    }
}
