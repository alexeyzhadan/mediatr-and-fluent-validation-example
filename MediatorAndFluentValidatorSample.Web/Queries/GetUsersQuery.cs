using MediatR;
using MediatrAndFluentValidationSample.Attributes;
using MediatrAndFluentValidationSample.Interfaces;
using MediatrAndFluentValidationSample.Models;

namespace MediatrAndFluentValidationSample.Queries;

[CacheDuration(1.0)]
public class GetUsersQuery : ICacheableQuery, IRequest<List<User>>
{
    public string GetCacheKey() => "Cache_GetUsersQuery";
}