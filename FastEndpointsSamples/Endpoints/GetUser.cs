using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointsSamples.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FastEndpointsSamples.Endpoints
{
    public class GetUserSummary : Summary<GetUser>
    {
        public GetUserSummary()
        {
            Summary = "Get User by ID";
            Description = """
                            This endpoint retrieves a user by their unique identifier. 
                            It returns the user's full name and whether they are over 18 years old.
                            """;
            ResponseExamples[200] = new UserResponse { FullName = "John Smith", IsOver18 = true };
            Responses[200] = "User found successfully.";
        }
    }

    public class GetUser : EndpointWithoutRequest<
        Results<Ok<UserResponse>, ProblemDetails>>
    {
        public override void Configure()
        {
            Get("/api/user/{userId}");
            AllowAnonymous();
            Description(b => b
                    .Produces<UserResponse>()
                    .ProducesProblemDetails()
                    .ProducesProblemFE<ProblemDetails>(404)
                    .ProducesProblemFE<ProblemDetails>(500)
                    .AutoTagOverride("Users"),
                clearDefaults: true);
        }

        public override Task<Results<Ok<UserResponse>, ProblemDetails>> ExecuteAsync(CancellationToken ct)
        {
            var userId = Route<int>("userId");

            // throw new Exception("This is a test exception to demonstrate the default exception handler.");

            return Task.FromResult<Results<Ok<UserResponse>, ProblemDetails>>(userId switch
            {
                0 => ReturnNotFoundProblemDetails(),
                -1 => ReturnProblemDetails(),
                _ => TypedResults.Ok(new UserResponse
                {
                    FullName = "John Doe",
                    IsOver18 = true
                })
            });
        }

        ProblemDetails ReturnNotFoundProblemDetails()
        {
            AddError("User not found");
            return new ProblemDetails(ValidationFailures, 404);
        }

        ProblemDetails ReturnProblemDetails()
        {
            AddError("User Identifier has to be greater than 0");
            return new ProblemDetails(ValidationFailures);
        }
    }
}
