using FastEndpoints;
using FluentValidation;

namespace FastEndpointsSamples.Models
{
    public class UserIdRequest
    {
        public int UserId { get; set; }
    }

    public class UserIdRequestValidator : Validator<UserIdRequest>
    {
        public UserIdRequestValidator()
        {
            RuleFor(x => x.UserId)
                .Must(x => x > 0).WithMessage("UserId must be greater than zero");

        }
    }
}
