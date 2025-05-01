using MediatR;

namespace TrackFetch.Api.Application.UseCases.Orders
{
	public class OrdersInput : IRequest<OrdersOutput>
	{
		public string Id { get; set; }
	}
}
