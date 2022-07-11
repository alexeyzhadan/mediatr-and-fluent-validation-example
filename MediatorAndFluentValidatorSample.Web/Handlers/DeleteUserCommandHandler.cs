using MediatR;
using MediatrAndFluentValidationSample.Commands;
using MediatrAndFluentValidationSample.Models;

namespace MediatrAndFluentValidationSample.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, EmptyModel>
{
    private readonly DbContext _context;

    public DeleteUserCommandHandler(DbContext context)
    {
        _context = context;
    }

    public Task<EmptyModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = _context.Users.SingleOrDefault(x => x.Id == request.Id);
        if (user != null)
        {
            _context.Users.Remove(user);
        }

        return Task.FromResult(new EmptyModel());
    }
}
