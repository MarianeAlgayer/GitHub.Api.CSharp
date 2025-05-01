using MediatR;

namespace TrackFetch.Api.Application.UseCases.Orders.Interfaces
{
	public interface IOrdersUseCase : IRequestHandler<OrdersInput, OrdersOutput> { }
}

