using RoboticsLabManagementSystem.Api.RequestHandler.CompanyHandler;
using FluentValidation;

namespace RoboticsLabManagementSystem.Api.Validators
{
    public class UpdateCompanyRequestValidator : AbstractValidator<UpdateCompanyRequestHandler>
    {
        public UpdateCompanyRequestValidator()
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

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email should not be empty")
                .Matches(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$")
                .WithMessage("Invalid email format");

            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Phone Number is required");

            RuleFor(x => x.Website)
                .NotNull()
                .NotEmpty()
                .WithMessage("Website is required")
                .Length(3, 25)
                .WithMessage("Website must be between 3 and 25 characters");
        }
    }
}
