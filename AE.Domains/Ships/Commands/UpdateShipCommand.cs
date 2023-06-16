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
    public class UpdateShipCommand : IRequest<UpdateShipVelocityDto>
    {
        public int Id { get; set; }
        public decimal Velocity { get; set; }


        public UpdateShipCommand(int id, decimal velocity) 
        {
            Id = id;
            Velocity = velocity;
        }
    }
}
