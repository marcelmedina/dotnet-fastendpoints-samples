using FastEndpoints;
using FastEndpointsSamples.Models;

namespace FastEndpointsSamples.Endpoints
{
    public class MyEndpoint : Endpoint<MyRequest, MyResponse>
    {
        public override void Configure()
        {
            Post("/api/user/create");
            AllowAnonymous();
        }

        public override Task HandleAsync(MyRequest req, CancellationToken ct)
        {
            Response = new()
            {
                FullName = $"{req.FirstName} {req.LastName}",
                IsOver18 = req.Age >= 18
            };
            return Task.CompletedTask;
        }
    }
}
