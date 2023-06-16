using AE.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AE.Repositories.Base;
using AE.Repositories.Dto;

namespace AE.Repositories.EntityRepoBase
{
    public interface IPortRepository : IGenericRepository<Port>
    {
        Task<GetShipPointRepoDto> GetNearestPointAsync(double lat, double lng);
    }
}
