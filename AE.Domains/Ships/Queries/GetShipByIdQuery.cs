using MediatR;
using AE.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AE.Domains.Ships.Dto;


namespace AE.Domains.Ships.Queries
{
    public class GetShipByIdQuery : IRequest<GetShipByIdDto>
    {
        public int Id { get; set; }
    }
}
