using MediatR;
using AE.Domains.Ships.Commands;
using AE.Domains.Ships.Dto;
using AE.Repositories.Base;

namespace AE.Domains.Ships.Handlers
{
    public class UpdateShipHandler : IRequestHandler<UpdateShipCommand, UpdateShipVelocityDto>
    {
        private readonly IRepositoryCenter _repositoryCenter;

        public UpdateShipHandler(IRepositoryCenter repositoryCenter)
        {
            _repositoryCenter = repositoryCenter;
        }

        public async Task<UpdateShipVelocityDto> Handle(UpdateShipCommand command, CancellationToken cancellationToken)
        {
            var shipEntity = await _repositoryCenter.ShipRepo.GetById(command.Id);
            if (shipEntity == null)
            {
                return null;
            }

            shipEntity.Velocity = command.Velocity;

            var result = await _repositoryCenter.ShipRepo.Update(shipEntity);
            await _repositoryCenter.CommitAsync();

            return new UpdateShipVelocityDto() {Id = result.Id, Velocity = result.Velocity};
        }
    }
}