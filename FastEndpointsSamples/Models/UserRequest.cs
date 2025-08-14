using FastEndpoints;
using FluentValidation;

namespace FastEndpointsSamples.Models
{
    public class UserRequest
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
    }

    public class UserRequestValidator : Validator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.UserId)
                .Must(x => x > 0).WithMessage("UserId must be greater than zero");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("your first name is required!")
                .MinimumLength(2).WithMessage("your first name is too short!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("your last name is required!")
                .MinimumLength(2).WithMessage("your last name is too short!");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("we need your age!")
                .GreaterThanOrEqualTo(18).WithMessage("you must be over 18 years old to register!");
        }
    }
}
