using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrackFetch.Api.Application.UseCases.Orders;

namespace TrackFetch.Api.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("v{version:apiversion}/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync(
        [Required][FromQuery] string orderId,
        CancellationToken cancellationToken)
    {
        var input = new OrdersInput()
        {
            Id = orderId
        };

        var output = await _mediator.Send(input, cancellationToken).ConfigureAwait(false);

        return Ok();
    }
}
