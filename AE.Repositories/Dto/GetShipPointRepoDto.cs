using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Repositories.Dto
{
    public class GetShipPointRepoDto
    {
        public int PortId { get; set; }
        public string PortName { get; set; }
        public double PortLat { get; set; }
        public double PortLong { get; set; }
        public double DistanceKMs { get; set; }
    }
}
