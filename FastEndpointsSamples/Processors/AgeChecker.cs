using FastEndpoints;
using FastEndpointsSamples.Models;

namespace FastEndpointsSamples.Processors
{
    public class AgeChecker : PreProcessor<UserRequest, MyStateBag>
    {
        public override Task PreProcessAsync(IPreProcessorContext<UserRequest> context, MyStateBag state, CancellationToken ct)
        {
            if (context.Request is { Age: >= 18 })
                state.IsValidAge = true;

            state.Status = $"age checked by pre-processor at {state.DurationMillis} ms.";

            return Task.CompletedTask;
        }
    }
}
