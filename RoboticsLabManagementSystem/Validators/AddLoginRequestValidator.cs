using RoboticsLabManagementSystem.Api.RequestHandler.AuthRequestHandler;
using FluentValidation;

namespace RoboticsLabManagementSystem.Api.Validators
{
    public class AddLoginRequestValidator : AbstractValidator<AddLoginRequestHandler>
    {
        public AddLoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email should not be null")
                .NotEmpty()
                .WithMessage("Email should not be empty")
                .Matches(@"^[a-zA-Z][a-zA-Z0-9._-]{3,}@(([a-zA-Z]{2,})+\.)+[a-zA-Z]\S{2,4}$")
                .WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password should not be null")
                .NotEmpty().WithMessage("Password should not be empty")
                .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*(),.?\"":{}|<>])\S{4,}$")
                .WithMessage("Invalid password format");
        }
    }
}
