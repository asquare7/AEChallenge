using Microsoft.Extensions.Logging;
using AE.Models.Data;
using AE.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Repositories.EntityRepoBase;

namespace AE.Repositories.EntityRepo
{
    public class ShipRepository : GenericRepository<Ship>, IShipRepository
    {
        public ShipRepository(AppDbContext context, ILogger logger) : base(context, logger)
        { 
        
        }
    }
}
