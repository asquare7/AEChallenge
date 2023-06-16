using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Domains.Ships.Dto
{
    public class GetNearestPortByShipIdDto
    {
        public PortDto PortDetails { get; set; }

        public double DistanceKMs { get; set; }
        public double EstimatedArraivalTimeHours { get; set; }
    }
}
