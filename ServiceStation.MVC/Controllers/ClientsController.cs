using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.Application.Clients.Queries.GetAllClients;
using ServiceStation.Application.ServiceStation.Queries.GetAllCar;

namespace ServiceStation.MVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _mediator.Send(new GetAllClientsQuery());
            return View(clients);
        }
    }
}
