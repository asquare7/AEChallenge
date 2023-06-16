using MediatR;
using AE.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Domains.Ships.Dto;

namespace AE.Domains.Ships.Commands
{
    public class CreateShipCommand : IRequest<CreateShipDto>
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public decimal Velocity { get; set; }

        public CreateShipCommand(string name, double latitude, double longitude,decimal velocity) 
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Velocity = velocity;
        }

        public CreateShipCommand()
        {
                
        }
    }
}
