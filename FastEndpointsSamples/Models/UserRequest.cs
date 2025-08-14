using FastEndpoints;
using FluentValidation;

namespace FastEndpointsSamples.Models
{
    public class UserRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
    }

    public class UserRequestValidator : Validator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("your first name is required!")
                .MinimumLength(2).WithMessage("your first name is too short!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("your last name is required!")
                .MinimumLength(2).WithMessage("your last name is too short!");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("we need your age!")
                .GreaterThan(18).WithMessage("you must be over 18 years old to register!");
        }
    }
}
