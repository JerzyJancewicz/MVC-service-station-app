using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters.");

            RuleFor(e => e.Surname)
                .NotEmpty().WithMessage("Surname is required")
                .MaximumLength(255).WithMessage("Surname must not exceed 255 characters.");

            RuleFor(client => client.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MinimumLength(9).WithMessage("Phone number contains 9 digits");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(client => client.Street)
                .NotEmpty().WithMessage("Street is required.")
                .MaximumLength(255).WithMessage("Street must not exceed 255 characters.");

            RuleFor(client => client.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City must not exceed 100 characters.");

            RuleFor(client => client.PostalCode)
                .NotEmpty().WithMessage("Postal code is required.")
                .MaximumLength(20).WithMessage("Postal code must not exceed 20 characters.");
        }
    }
}
