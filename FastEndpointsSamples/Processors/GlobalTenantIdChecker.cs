using FastEndpoints;

namespace FastEndpointsSamples.Processors
{
    public class GlobalTenantIdChecker : IGlobalPreProcessor
    {
        public async Task PreProcessAsync(IPreProcessorContext ctx, CancellationToken ct)
        {
            if (ctx.Request is not null) //can work on specific dto types if desired
            {
                var tenantId = ctx.HttpContext.Request.Headers["x-tenant-id"];

                if (tenantId.Count == 0)
                {
                    ctx.ValidationFailures.Add(
                        new("TenantId", "Unable to retrieve tenant id from header!"));

                    if (!ctx.HttpContext.ResponseStarted())
                        await ctx.HttpContext.Response.SendErrorsAsync(ctx.ValidationFailures, cancellation: ct);
                }
            }
        }
    }
}
