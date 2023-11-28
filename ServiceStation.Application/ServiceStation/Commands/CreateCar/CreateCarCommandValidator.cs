using FluentValidation;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Commands.CreateCar
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator(IServiceStationRepository repository)
        {
            RuleFor(c => c.LicensePlate)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(10)
                .Custom((value, context) =>
                {
                    var existingCar = repository.GetByName(value).Result;
                    if (existingCar != null)
                    {
                        context.AddFailure($"Car with license plate {value} already exists");
                    }
                });
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(20);

        }
    }
}
