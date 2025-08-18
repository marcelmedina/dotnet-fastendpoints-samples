using FastEndpoints;
using FastEndpointsSamples.Events;
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
            await PublishAsync(new UserCreatedEvent
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Age = req.Age,
                DateCreated = DateTime.UtcNow
            }, Mode.WaitForAll, ct);

            await Send.OkAsync(new UserResponse
            {
                FullName = $"{req.FirstName} {req.LastName}",
                IsOver18 = req.Age >= 18
            }, ct);
        }
    }
}
