using MediatR;
using MediatrAndFluentValidationSample.Models;

namespace MediatrAndFluentValidationSample.Queries;

public class GetUserByIdQuery : IRequest<User>
{
    public long Id { get; set; }
}