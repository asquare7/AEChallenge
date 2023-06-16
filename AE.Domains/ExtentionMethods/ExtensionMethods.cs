using MediatR;
using AE.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AE.Domains.Ships.Commands;
using AE.Domains.Ships.Dto;
using Math = System.Math;


namespace AE.Domains.Ships.Queries
{
    public static class MapToDtoExtensions
    {
        public static GetShipByIdDto MapToDto(this Ship ship)
        {
            return new GetShipByIdDto
            {
                Id = ship.Id,
                Name = ship.Name,
                Latitude = ship.Latitude,
                Longitude = ship.Longitude,
                Velocity = ship.Velocity
            };
        }

        public static List<GetShipByIdDto> MapToDto(this IEnumerable<Ship> ship)
        {
            List<GetShipByIdDto> temp = new List<GetShipByIdDto>();
            foreach (Ship shipItem in ship)
            {
                temp.Add(MapToDto(shipItem));
            }

            return temp;
        }

        public static PortDto MapToDto(this Port port)
        {
            return new PortDto {Id = port.Id, Name = port.Name, Latitude = port.Latitude, Longitude = port.Longitude};
        }
    }
}