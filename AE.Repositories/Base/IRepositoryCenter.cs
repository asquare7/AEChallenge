using AE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Repositories.EntityRepoBase;

namespace AE.Repositories.Base
{
    public interface IRepositoryCenter
    {
        IShipRepository ShipRepo { get; }
        IPortRepository PortRepo { get; }
        Task CommitAsync();
        void Dispose();
    }
}
