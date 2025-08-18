using FastEndpoints;
using FastEndpointsSamples.Models;

namespace FastEndpointsSamples.Processors
{
    public class SecurityProcessor : IPreProcessor<UserRequest>
    {
        public Task PreProcessAsync(IPreProcessorContext<UserRequest> context, CancellationToken ct)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("x-tenant-id", out var tenantId))
            {
                context.ValidationFailures.Add(
                    new("MissingHeaders", "The [x-tenant-id] header needs to be set!"));

                //sending response here
                return context.HttpContext.Response.SendErrorsAsync(context.ValidationFailures, cancellation: ct);
            }

            if (tenantId != "001")
                return context.HttpContext.Response.SendForbiddenAsync(cancellation: ct); //sending response here

            return Task.CompletedTask;
        }
    }
}
