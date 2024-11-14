using CustomerService.Application.Command.Create;
using FluentValidation;

namespace CustomerService.Application.Validator
{
    public class CreateCustomerProfileValidator : AbstractValidator<CreateCustomerProfileCommand>
    {
        public CreateCustomerProfileValidator()
        {
            RuleFor(cust => cust.FirstName)
                    .NotEmpty().WithMessage("First name is mandatory")
                    .MinimumLength(5).WithMessage("First name must be length of 5.")
                    .MaximumLength(50).WithMessage("First name cannot exceed length of 50.");
            RuleFor(cust => cust.LastName)
                       .NotEmpty().WithMessage("First name is mandatory")
                       .MinimumLength(5).WithMessage("First name must be length of 5.")
                       .MaximumLength(50).WithMessage("First name cannot exceed length of 50.");
            RuleFor(cust => cust.Address).NotEmpty().WithMessage("Address is mandatory").MaximumLength(100).WithMessage("Address cannot exceed length of 100");
            RuleFor(cust => cust.PhoneNumber).NotEmpty().WithMessage("Phone number is mandatory").MaximumLength(10).WithMessage("Phone number must be of 10 digits");
            RuleFor(cust => cust.DateOfBirth)
                    .NotEmpty().WithMessage("DOB is mandatory")
                    .Must(BeAtLeast18YearsOld)
                    .WithMessage("Person must be at least 18 years old.");
        }

        private bool BeAtLeast18YearsOld(DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;

            // Adjust age if the birthdate has not occurred yet this year
            if (dob > today.AddYears(-age))
            {
                age--;
            }

            return age >= 18;
        }

    }
}
