using RoboticsLabManagementSystem.Api.RequestHandler.AuthRequestHandler;
using FluentValidation;

namespace RoboticsLabManagementSystem.Api.Validators
{
    public class AddTokenRequestValidator:AbstractValidator<AddTokenRequestHandler>
    {
        public AddTokenRequestValidator()
        {
            RuleFor(x => x.Token)
                .NotNull()
                .WithMessage("Token should not be null")
                .NotEmpty()
                .WithMessage("Token should not be empty");
        }
    }
}
