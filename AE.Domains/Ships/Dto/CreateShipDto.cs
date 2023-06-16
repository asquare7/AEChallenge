using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Domains.Ships.Dto
{
    public class CreateShipDto
    {
        public CreateShipDto(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
