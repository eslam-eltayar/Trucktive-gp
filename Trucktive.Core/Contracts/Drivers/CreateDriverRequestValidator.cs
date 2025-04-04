using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucktive.Core.Contracts.Drivers
{
    public class CreateDriverRequestValidator : AbstractValidator<CreateDriverRequest>
    {
        public CreateDriverRequestValidator()
        {
            RuleFor(d => d.FName)
           .NotEmpty().WithMessage("First name is required")
           .MaximumLength(100).WithMessage("First name cannot exceed 100 characters");

            RuleFor(d => d.LName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters");

            RuleFor(d => d.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters");

            RuleFor(d => d.Phone)
                .NotEmpty().WithMessage("Phone number is required")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters")
                .Matches(@"^\+?\d{7,20}$").WithMessage("Phone number format is invalid");

            RuleFor(d => d.Address)
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters");
        }
    }
}
