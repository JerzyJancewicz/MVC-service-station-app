using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.Application.ServiceStation;
using ServiceStation.Application.ServiceStation.Commands.CreateCar;
using ServiceStation.Application.ServiceStation.Commands.DeleteCar;
using ServiceStation.Application.ServiceStation.Commands.UpdateCar;
using ServiceStation.Application.ServiceStation.Queries.GetAllCar;
using ServiceStation.Application.ServiceStation.Queries.GetAllClientsCar;
using ServiceStation.Application.ServiceStation.Queries.GetCarByLicansePlate;
using ServiceStation.Domain.Entities.Clients;

namespace ServiceStation.MVC.Controllers
{
    public class ServiceStationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper mapper;

        public ServiceStationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            this.mapper = mapper;
        }

        [Route("Clients/{Id}/Car")]
        public async Task<IActionResult> CarIndex(int Id)
        {
            var cars = await _mediator.Send(new GetAllClientsCarQuery(Id));

            return View(cars);
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _mediator.Send(new GetAllCarQuery());

            return View(cars);
        }

        [Route("Car/{LicensePlate}/Details")]
        public async Task<IActionResult> Details(string LicensePlate)
        {
            var carDto = await _mediator.Send(new GetCarByLicensePlateQuery(LicensePlate));
            return View(carDto);
        }

        [Route("Car/{LicensePlate}/Edit")]
        public async Task<IActionResult> Edit(string LicensePlate)
        {
            var carDto = await _mediator.Send(new GetCarByLicensePlateQuery(LicensePlate));

            if (!carDto.IsEditable)
            {
                //      Przyjmuje Widok, i kontroler
                return RedirectToAction("NoAccess", "Home");
            }

            UpdateCarCommand model = mapper.Map<UpdateCarCommand>(carDto);
            return View(model);
        }

        [HttpPost]
        [Route("Car/{LicensePlate}/Edit")]
        public async Task<IActionResult> Edit(string LicensePlate, UpdateCarCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        [Route("Clients/{Id}/Car/Create")]
        public async Task<IActionResult> Create(int Id,CreateCarCommand command) 
        {
            if (!ModelState.IsValid) 
            {
                return View(command);
            }
            command.IdClient = Id;
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("Car/{LicensePlate}/Delete")]
        public async Task<IActionResult> Delete(string LicensePlate)
        {
            var carDto = await _mediator.Send(new GetCarByLicensePlateQuery(LicensePlate));
            DeleteCarCommand model = mapper.Map<DeleteCarCommand>(carDto);
            return View(model);
        }

        [HttpPost]
        [Route("Car/{LicensePlate}/Delete")]
        public async Task<IActionResult> Delete(DeleteCarCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
