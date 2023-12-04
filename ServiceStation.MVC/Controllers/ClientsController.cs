using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.Application.Clients.Commands.CreateClient;
using ServiceStation.Application.Clients.Commands.DeleteClient;
using ServiceStation.Application.Clients.Commands.UpdateClient;
using ServiceStation.Application.Clients.Queries.GetAllClients;
using ServiceStation.Application.Clients.Queries.GetClientById;
using ServiceStation.Application.ServiceStation.Commands.DeleteCar;
using ServiceStation.Application.ServiceStation.Queries.GetCarByLicansePlate;

namespace ServiceStation.MVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClientsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _mediator.Send(new GetAllClientsQuery());
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("Client/{Id}/Edit")]
        public async Task<IActionResult> Edit(int Id)
        {
            var clientDto = await _mediator.Send(new GetClientByIdQuery(Id));

            UpdateClientCommand model = _mapper.Map<UpdateClientCommand>(clientDto);
            return View(model);
        }

        [HttpPost]
        [Route("Client/{Id}/Edit")]
        public async Task<IActionResult> Edit(int Id, UpdateClientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("Client/{Id}/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var clientDto = await _mediator.Send(new GetClientByIdQuery(Id));
            DeleteClientCommand model = _mapper.Map<DeleteClientCommand>(clientDto);
            return View(model);
        }

        [HttpPost]
        [Route("Client/{Id}/Delete")]
        public async Task<IActionResult> Delete(DeleteClientCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("Client/{Id}/Details")]
        public async Task<IActionResult> Details(int Id)
        {
            var carDto = await _mediator.Send(new GetClientByIdQuery(Id));
            return View(carDto);
        }
    }
}
