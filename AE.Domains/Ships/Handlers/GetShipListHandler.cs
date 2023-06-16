using MediatR;
using AE.Models.Models;
using AE.Repositories.Base;
using AE.Repositories.EntityRepoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Domains.Ships.Dto;
using AE.Domains.Ships.Queries;

namespace AE.Domains.Ships.Handlers
{
    public class GetShipListHandler : IRequestHandler<GetShipListQuery, List<GetShipByIdDto>>
    {
        private readonly IRepositoryCenter _repositoryCenter;

        public GetShipListHandler(IRepositoryCenter repositoryCenter)
        {
            _repositoryCenter = repositoryCenter;
        }

        public async Task<List<GetShipByIdDto>> Handle(GetShipListQuery query, CancellationToken cancellationToken)
        {
            var shipListEntity = await _repositoryCenter.ShipRepo.All();
            if (shipListEntity == null)
                return null;

            return shipListEntity.MapToDto();
        }
    }
}