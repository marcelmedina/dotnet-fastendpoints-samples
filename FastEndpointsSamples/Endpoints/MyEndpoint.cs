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

        // Using HandleAsync (recommended approach)
        public override Task HandleAsync(MyRequest req, CancellationToken ct)
        {
            Response = new()
            {
                FullName = $"{req.FirstName} {req.LastName}",
                IsOver18 = req.Age >= 18
            };
            return Task.CompletedTask;
        }

        // Alternative implementation using ExecuteAsync
        /*public override Task<MyResponse> ExecuteAsync(MyRequest req, CancellationToken ct)
        {
            var response = new MyResponse
            {
                FullName = $"{req.FirstName} {req.LastName}",
                IsOver18 = req.Age >= 18
            };

            // Manually send the response
            return Task.FromResult(response);
        }*/
    }
}
