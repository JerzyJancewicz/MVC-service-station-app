using Microsoft.AspNetCore.Mvc;
using ServiceStation.Application.Services;
using ServiceStation.Application.ServiceStation;
using ServiceStation.Domain.Entities.Clients;

namespace ServiceStation.MVC.Controllers
{
    public class ServiceStationController : Controller
    {
        private readonly IServiceStationService serviceStationService;

        public ServiceStationController(IServiceStationService serviceStationService)
        {
            this.serviceStationService = serviceStationService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await serviceStationService.GetAll();

            return View(cars);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarDto car) 
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }
            await serviceStationService.Create(car);
            return RedirectToAction(nameof(Create));
        }
    }
}
