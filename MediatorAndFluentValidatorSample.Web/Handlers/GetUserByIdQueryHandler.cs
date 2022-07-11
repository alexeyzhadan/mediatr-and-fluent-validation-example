using MediatR;
using MediatrAndFluentValidationSample.Models;
using MediatrAndFluentValidationSample.Queries;

namespace MediatrAndFluentValidationSample.Handlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly DbContext _context;

    public GetUserByIdQueryHandler(DbContext context)
    {
        _context = context;
    }

    public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == request.Id);

        return Task.FromResult(user);
    }
}
