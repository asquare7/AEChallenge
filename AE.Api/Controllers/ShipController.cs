using AE.Domains.Ships.Commands;
using AE.Domains.Ships.Dto;
using AE.Domains.Ships.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AE.Models.Models;

namespace AE.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipController : Controller
    {
        private readonly IMediator _mediator;

        public ShipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetShipById")]
        public async Task<GetShipByIdDto> GetShipByIdAsync(int shipId)
        {
            var shipDetails = await _mediator.Send(new GetShipByIdQuery() { Id = shipId });

            return shipDetails;
        }

        [HttpGet("GetShipList")]
        public async Task<List<GetShipByIdDto>> GetShipListAsync()
        {
            var shipsDetails = await _mediator.Send(new GetShipListQuery());

            return shipsDetails;
        }

        [HttpPost("AddShip")]
        public async Task<CreateShipDto> AddShipAsync(GetShipByIdDto ship)
        {
            var shipDetails = await _mediator.Send(new CreateShipCommand()
            {
                Latitude = ship.Latitude,
                Longitude = ship.Longitude,
                Name = ship.Name,
                Velocity = ship.Velocity
            });

            return shipDetails;
        }

        [HttpPost("UpdateShipVelocity")]
        public async Task<UpdateShipVelocityDto> UpdateShipVelocityAsync(UpdateShipVelocityDto ship)
        {
            var shipDetails = await _mediator.Send(new UpdateShipCommand(ship.Id, ship.Velocity));

            return shipDetails;
        }

        [HttpPost("GetNearestPortByShipID")]
        public async Task<GetNearestPortByShipIdDto> GetNearestPortByShipIdAsync(int shipId)
        {
            var portDetails = await _mediator.Send(new GetNearestPortByShipIDQuery() { Id = shipId });

            return portDetails; 
        }
    }
}
