using System.Runtime.InteropServices;
using AE.Models.Base;

namespace AE.Models.Models
{
    public class Ship : IEntity, IAudit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public decimal Velocity { get; set; } 

        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ChangedBy { get; set; }
        public DateTime? ChangedDate { get; set; }
    }
}
