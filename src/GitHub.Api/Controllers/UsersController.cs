using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GitHub.Api.Application.UseCases.Users;

namespace GitHub.Api.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("v{version:apiversion}/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync(
        [Required][FromQuery] int id,
        CancellationToken cancellationToken)
    {
        var input = new UsersInput()
        {
            Id = id
        };

        var output = await _mediator.Send(input, cancellationToken).ConfigureAwait(false);

        return Ok(output);
    }
}
