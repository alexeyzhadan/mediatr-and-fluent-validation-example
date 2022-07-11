using MediatR;
using MediatrAndFluentValidationSample.Commands;
using MediatrAndFluentValidationSample.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatrAndFluentValidationSample.Controllers;

[ApiController]
[Route("Api/Users")]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var users = await mediator.Send(new GetUsersQuery(), cancellationToken);

        return Ok(users);
    }

    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(query, cancellationToken);

        return user != null
            ? Ok(user)
            : NotFound();
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(command, cancellationToken);

        return user != null
            ? Ok(user)
            : BadRequest();
    }

    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser([FromQuery] DeleteUserCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);

        return Ok();
    }
}