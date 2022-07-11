using MediatR;
using MediatrAndFluentValidationSample.Commands;
using MediatrAndFluentValidationSample.Models;

namespace MediatrAndFluentValidationSample.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly DbContext _context;

    public CreateUserCommandHandler(DbContext context)
    {
        _context = context;
    }

    public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = (_context.Users.LastOrDefault()?.Id ?? 0) + 1,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
        _context.Users.Add(user);

        return Task.FromResult(user);
    }
}
