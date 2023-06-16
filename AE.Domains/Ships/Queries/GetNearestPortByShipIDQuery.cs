using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Domains.Ships.Dto;

namespace AE.Domains.Ships.Queries
{
    public class GetNearestPortByShipIDQuery : IRequest<GetNearestPortByShipIdDto>
    {
        public int Id { get; set; }
    }
}
