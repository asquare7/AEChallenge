using AE.Domains.Ships.Dto;
using MediatR;
using AE.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AE.Domains.Ships.Commands;
using Math = System.Math;


namespace AE.Domains.Ships.Queries
{
    public static class MapToEntityExtensions
    {
        public static Ship CreateShipEntity(this CreateShipCommand shipCommand)
        {
            var shipEntity = new Ship()
            {
                Name = shipCommand.Name,
                Longitude = shipCommand.Longitude,
                Latitude = shipCommand.Latitude,
                Velocity = shipCommand.Velocity
            };

            return shipEntity;
        }
    }
}