using FastEndpoints;
using FastEndpointsSamples.Commands;
using FastEndpointsSamples.Models;

namespace FastEndpointsSamples.Endpoints
{
    public class CreateUser : Endpoint<UserRequest, UserResponse>
    {
        public override void Configure()
        {
            Post("/api/user/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UserRequest req, CancellationToken ct)
        {
            var fullName = await new GetFullName()
                {
                    FirstName = req.FirstName,
                    LastName = req.LastName
                }
                .ExecuteAsync(ct: ct);

            await Send.OkAsync(new UserResponse
            {
                FullName = fullName,
                IsOver18 = req.Age >= 18
            }, ct);
        }
    }
}
