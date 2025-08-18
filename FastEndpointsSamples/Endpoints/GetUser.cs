using FastEndpoints;
using FastEndpointsSamples.Models;
using FastEndpointsSamples.Processors;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FastEndpointsSamples.Endpoints
{
    public class GetUser : EndpointWithoutRequest<
        Results<Ok<UserResponse>,
            NotFound,
            ProblemDetails>>
    {
        public override void Configure()
        {
            Get("/api/user/{userId}");
            AllowAnonymous();
            PreProcessor<RequestLogger<GetUser>>();
            PostProcessor<ResponseLogger<UserResponse>>();
        }

        public override Task<Results<Ok<UserResponse>, NotFound, ProblemDetails>> ExecuteAsync(CancellationToken ct)
        {
            var userId = Route<int>("userId");

            return Task.FromResult<Results<Ok<UserResponse>, NotFound, ProblemDetails>>(userId switch
            {
                0 => TypedResults.NotFound(),
                -1 => ReturnProblemDetails(),
                _ => TypedResults.Ok(new UserResponse
                {
                    FullName = "John Doe",
                    IsOver18 = true
                })
            });
        }

        ProblemDetails ReturnProblemDetails()
        {
            AddError("User Identifier has to be greater than 0");
            return new ProblemDetails(ValidationFailures);
        }
    }
}
