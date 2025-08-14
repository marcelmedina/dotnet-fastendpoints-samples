using FastEndpoints;
using FastEndpointsSamples.Models;

namespace FastEndpointsSamples.Endpoints
{
    public class CreateUser : Endpoint<UserRequest, UserResponse, UserMapper>
    {
        public override void Configure()
        {
            Post("/api/user/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UserRequest req, CancellationToken ct)
        {
            var user = Map.ToEntity(req);
            var userResponse = Map.FromEntity(user);
            await Send.OkAsync(userResponse, ct);
        }
    }
}
