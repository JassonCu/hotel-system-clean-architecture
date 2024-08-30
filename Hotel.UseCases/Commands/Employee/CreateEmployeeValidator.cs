using FluentValidation;

namespace Hotel.UseCases.Commands.Employee
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator() {
            RuleFor(x => x.FirstName)
               .NotEmpty().WithMessage("First name is required.")
               .Length(1, 50).WithMessage("First name must be between 1 and 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(1, 50).WithMessage("Last name must be between 1 and 50 characters.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email address.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Salary)
                .GreaterThan(0).WithMessage("Salary must be greater than 0.")
                .When(x => x.Salary.HasValue);

            RuleFor(x => x.HireDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Hire date cannot be in the future.")
                .When(x => x.HireDate.HasValue);

            RuleFor(x => x.Address)
                .Length(0, 100).WithMessage("Address must be up to 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.Address));

            RuleFor(x => x.City)
                .Length(0, 50).WithMessage("City must be up to 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.City));

            RuleFor(x => x.State)
                .Length(0, 50).WithMessage("State must be up to 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.State));

            RuleFor(x => x.PostalCode)
                .Length(0, 20).WithMessage("Postal code must be up to 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.PostalCode));

            RuleFor(x => x.Country)
                .Length(0, 50).WithMessage("Country must be up to 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.Country));
        }
    }
}
