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

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarDto car) 
        {
            await serviceStationService.Create(car);
            return RedirectToAction(nameof(Create));
        }
    }
}
