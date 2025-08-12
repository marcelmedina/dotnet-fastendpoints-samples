using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsSamples.Models;

namespace FastEndpointsSamples.Endpoints
{
    public class CreateUser : Endpoint<UserRequest, UserResponse>
    {
        public override void Configure()
        {
            Post("/api/user/create");
            AllowAnonymous();
            Description(b => b.AutoTagOverride("Users"));
        }

        public override async Task HandleAsync(UserRequest req, CancellationToken ct)
        {
            await Send.OkAsync(new UserResponse
            {
                FullName = $"{req.FirstName} {req.LastName}",
                IsOver18 = req.Age >= 18
            }, ct);
        }
    }
}
