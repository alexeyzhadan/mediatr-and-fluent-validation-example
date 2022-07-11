using MediatR;
using MediatrAndFluentValidationSample.Models;

namespace MediatrAndFluentValidationSample.Commands;

public class CreateUserCommand : IRequest<User>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}