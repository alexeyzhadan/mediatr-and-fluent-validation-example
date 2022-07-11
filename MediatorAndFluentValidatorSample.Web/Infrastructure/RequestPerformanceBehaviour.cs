using MediatR;
using System.Diagnostics;

namespace MediatrAndFluentValidationSample.Infrastructure;

public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch timer;
    private readonly ILogger<TRequest> logger;

    public RequestPerformanceBehaviour(ILogger<TRequest> logger)
    {
        this.timer = new Stopwatch();
        this.logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        timer.Start();

        var response = await next();

        timer.Stop();

        if (timer.ElapsedMilliseconds > 500)
        {
            logger.LogWarning($"Long Running Request: {typeof(TRequest).Name} ({timer.ElapsedMilliseconds} milliseconds) {request}");
        }

        return response;
    }
}