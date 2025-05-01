using TrackFetch.Api.Application.UseCases.Orders;
using TrackFetch.Api.Application.UseCases.Orders.Interfaces;

namespace TrackFetch.Api.DependencyInjection
{
	public static class ApplicationExtensions
	{
		public static IServiceCollection AddUseCases(this IServiceCollection services)
		{
			services.AddScoped<IOrdersUseCase, OrdersUseCase>();

			return services;
		}
	}
}

