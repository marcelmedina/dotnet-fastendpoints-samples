using FastEndpoints;
using FastEndpointsSamples.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FastEndpointsSamples.Processors
{
    public class ResponseLogger<TResponse> : IPostProcessor<EmptyRequest, Results<Ok<UserResponse>, NotFound, ProblemDetails>>
    {
        public Task PostProcessAsync(IPostProcessorContext<EmptyRequest, Results<Ok<UserResponse>, NotFound, ProblemDetails>> context, CancellationToken ct)
        {
            var logger = context.HttpContext.Resolve<ILogger<TResponse>>();

            if (context.Response is { } results)
            {
                var (message, args) = results.Result switch
                {
                    Ok<UserResponse> { Value: { } userResponse } => ("Response: {FullName}", new object[] { userResponse.FullName }),
                    NotFound => ("Response: NotFound", Array.Empty<object>()),
                    ProblemDetails problem => ("Response: ProblemDetails - {Title}", new object[] { problem.Title }),
                    _ => (null, null)
                };

                if (message is not null)
                    logger.LogWarning(message, args);
            }

            return Task.CompletedTask;
        }
    }
}
