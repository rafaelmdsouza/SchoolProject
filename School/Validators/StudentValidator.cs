using FluentValidation;
using School.API.Application.Command;

namespace School.API.Validators
{
    public class StudentValidator : AbstractValidator<AddStudentCommand>
    {
        public StudentValidator() 
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("First name is required")
                .MaximumLength(50).WithMessage("First name must be less than 50 characters.");

            RuleFor(s => s.LastName).NotEmpty().WithMessage("Last name is required")
                .MaximumLength(100).WithMessage("First name must be less than 50 characters.");

            RuleFor(s => s.Age).NotEmpty().WithMessage("Age is required.");

            RuleFor(s => s.Phone).NotEmpty().WithMessage("Phone is required");

            RuleFor(s => s.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("A valid email is declared");


        }
    }
}
