using FluentValidation;
using ServiceStation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Commands.UpdateCar
{
    public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarCommandValidator(IServiceStationRepository repository)
        {
            RuleFor(c => c.CarName)
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
