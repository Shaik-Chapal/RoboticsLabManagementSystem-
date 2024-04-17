using RoboticsLabManagementSystem.Api.RequestHandler.BranchHandler;
using FluentValidation;

namespace RoboticsLabManagementSystem.Api.Validators
{
    public class AddBranchRequestValidator : AbstractValidator<AddBranchRequestHandler>
    {
        public AddBranchRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required")
                .Length(2, 25)
                .WithMessage("Name must be between 2 and 25 characters");

            RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .WithMessage("Address is required")
                .Length(5, 100)
                .WithMessage("Address must be between 5 and 100 characters");

    
            RuleFor(x => x.Phone)
              .NotNull()
              .NotEmpty()
              .WithMessage("Phone Number is required");
        }
    }
}
