﻿using FluentValidation;
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
                    var encodeValue = value.ToUpper().Replace(" ", "");
                    var existingCar = repository.GetByName(encodeValue).Result;

                    if (existingCar != null)
                    {
                        context.AddFailure($"Car with license plate {encodeValue} already exists");
                    }
                });
            RuleFor(c => c.CarName)
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
