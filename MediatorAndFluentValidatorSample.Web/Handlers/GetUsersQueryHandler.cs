using MediatR;
using MediatrAndFluentValidationSample.Models;
using MediatrAndFluentValidationSample.Queries;

namespace MediatrAndFluentValidationSample.Handlers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
{
    private readonly DbContext _dbContext;

    public GetUsersQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dbContext.Users);
    }
}