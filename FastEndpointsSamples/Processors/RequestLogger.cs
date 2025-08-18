using FastEndpoints;

namespace FastEndpointsSamples.Processors
{
    public class RequestLogger<TRequest> : IPreProcessor<EmptyRequest>
    {
        public Task PreProcessAsync(IPreProcessorContext<EmptyRequest> context, CancellationToken ct)
        {
            var logger = context.HttpContext.Resolve<ILogger<TRequest>>();

            logger.LogInformation(
                $"request:{context.Request.GetType().FullName} path: {context.HttpContext.Request.Path}");

            return Task.CompletedTask;
        }

        public Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
        {
            var logger = context.HttpContext.Resolve<ILogger<TRequest>>();

            logger.LogInformation(
                $"request:{context.Request?.GetType().FullName} path: {context.HttpContext.Request.Path}");

            return Task.CompletedTask;
        }
    }
}
