using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Domains.Ships.Dto
{
    public class GetShipByIdDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Latitude Required!")]
        [Range(-90, 90, ErrorMessage = "Value for Latitude must be between -90 and 90.")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Longitude Required!")]
        [Range(-180, 180, ErrorMessage = "Value for Longitude must be between -180 and 180.")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "Velocity Required!")]
        public decimal Velocity { get; set; }
    }
}
