using MediatR;
using MediatrAndFluentValidationSample.Attributes;
using MediatrAndFluentValidationSample.Interfaces;

namespace MediatrAndFluentValidationSample.Infrastructure;

public class CacheQueryBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICacheableQuery, IRequest<TResponse>
        where TResponse : new()
{
    private readonly ICacheService cacheService;

    public CacheQueryBehavior(ICacheService cacheService)
    {
        this.cacheService = cacheService;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        TResponse result;

        var key = request.GetCacheKey();

        if (cacheService.KeyExists(key))
        {
            cacheService.GetCache(key, out result);
            return result;
        }

        result = await next();

        if (result != null)
        {
            var cacheDuration = request
                .GetType()
                .GetCustomAttributes(typeof(CacheDurationAttribute), true)
                .OfType<CacheDurationAttribute>()
                .FirstOrDefault();
            if (cacheDuration != null)
            {
                cacheService.SaveCache(key, result, cacheDuration.Hours);
            }
            else
            {
                cacheService.SaveCache(key, result);
            }
        }

        return result;
    }
}