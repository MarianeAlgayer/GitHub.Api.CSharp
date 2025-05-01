using TrackFetch.Api.Application.UseCases.Orders.Interfaces;

namespace TrackFetch.Api.Application.UseCases.Orders
{
    public class OrdersUseCase : IOrdersUseCase
    {
        public async Task<OrdersOutput> Handle(OrdersInput request, CancellationToken cancellationToken)
        {
            return new OrdersOutput() { Id = 1 };
        }
    }
}

