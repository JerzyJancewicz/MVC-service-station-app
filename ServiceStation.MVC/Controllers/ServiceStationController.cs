using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.Application.ServiceStation;
using ServiceStation.Application.ServiceStation.Commands.CreateCar;
using ServiceStation.Application.ServiceStation.Queries.GetAllCar;
using ServiceStation.Application.ServiceStation.Queries.GetCarByLicansePlate;
using ServiceStation.Domain.Entities.Clients;

namespace ServiceStation.MVC.Controllers
{
    public class ServiceStationController : Controller
    {
        private readonly IMediator _mediator;

        public ServiceStationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _mediator.Send(new GetAllCarQuery());

            return View(cars);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [Route("Car/{LicensePlate}/Details")]
        public async Task<IActionResult> Details(string LicensePlate)
        {
            var carDto = await _mediator.Send(new GetCarByLicensePlateQuery(LicensePlate));
            return View(carDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarCommand command) 
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
