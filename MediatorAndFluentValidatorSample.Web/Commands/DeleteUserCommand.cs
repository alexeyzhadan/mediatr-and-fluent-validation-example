using MediatR;
using MediatrAndFluentValidationSample.Models;

namespace MediatrAndFluentValidationSample.Commands;

public class DeleteUserCommand : IRequest<EmptyModel>
{
    public long Id { get; set; }
}