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
    public class GetShipByIdHandler : IRequestHandler<GetShipByIdQuery, GetShipByIdDto>
    {
        private readonly IRepositoryCenter _repositoryCenter;

        public GetShipByIdHandler(IRepositoryCenter repositoryCenter)
        {
            _repositoryCenter = repositoryCenter;
        }

        public async Task<GetShipByIdDto> Handle(GetShipByIdQuery query, CancellationToken cancellationToken)
        {
            var shipEntity = await _repositoryCenter.ShipRepo.GetById(query.Id);
            if (shipEntity == null)
                return null;

            return shipEntity.MapToDto();
        }
    }
}