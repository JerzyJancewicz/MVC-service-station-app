﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.ServiceStation.Commands.DeleteCar
{
    public class DeleteCarCommand :CarDto, IRequest
    {

    }
}
