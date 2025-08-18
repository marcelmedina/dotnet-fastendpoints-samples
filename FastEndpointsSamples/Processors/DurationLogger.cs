using FastEndpoints;
using FastEndpointsSamples.Models;

namespace FastEndpointsSamples.Processors
{
    public class DurationLogger : PostProcessor<UserRequest, MyStateBag, object>
    {
        public override Task PostProcessAsync(IPostProcessorContext<UserRequest, object> ctx,
            MyStateBag state,
            CancellationToken ct)
        {
            ctx.HttpContext.Resolve<ILogger<DurationLogger>>()
                .LogInformation("request took {@duration} ms.", state.DurationMillis);

            return Task.CompletedTask;
        }
    }
}
