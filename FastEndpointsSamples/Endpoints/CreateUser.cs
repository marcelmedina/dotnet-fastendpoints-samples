using FastEndpoints;
using FastEndpointsSamples.Models;
using FastEndpointsSamples.Processors;

namespace FastEndpointsSamples.Endpoints
{
    public class CreateUser : Endpoint<UserRequest, UserResponse>
    {
        public override void Configure()
        {
            Post("/api/user/create");
            AllowAnonymous();
            //PreProcessor<SecurityProcessor>();
            PreProcessor<AgeChecker>();
            PostProcessor<DurationLogger>();
        }

        public override async Task HandleAsync(UserRequest req, CancellationToken ct)
        {
            var state = ProcessorState<MyStateBag>();
            Logger.LogInformation("endpoint executed at {@duration} ms.", state.DurationMillis);

            await Send.OkAsync(new UserResponse
            {
                FullName = $"{req.FirstName} {req.LastName}",
                IsOver18 = state.IsValidAge
            }, ct);
        }
    }
}
