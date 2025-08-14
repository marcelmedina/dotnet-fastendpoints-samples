using FastEndpoints;
using FastEndpointsSamples.Models;

namespace FastEndpointsSamples.Endpoints
{
    public class GetUser : Endpoint<UserIdRequest, UserResponse>
    {
        public override void Configure()
        {
            Get("/api/user/{userId}");
            AllowAnonymous();
            DontThrowIfValidationFails();
        }

        public override Task<Task> HandleAsync(UserIdRequest req, CancellationToken ct)
        {
            if (req.UserId <= 0)
            {
                AddError("User Identifier has to be greater than 0");
            }

            ThrowIfAnyErrors();

            return Task.FromResult(Send.OkAsync(new UserResponse
            {
                FullName = "John Doe",
                IsOver18 = true
            }, ct));
        }
    }
}
