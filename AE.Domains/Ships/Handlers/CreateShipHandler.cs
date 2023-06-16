using MediatR;
using AE.Domains.Ships.Queries;
using AE.Domains.Ships.Commands;
using AE.Domains.Ships.Dto;
using AE.Repositories.Base;

namespace AE.Domains.Ships.Handlers
{
    public class CreateShipHandler : IRequestHandler<CreateShipCommand, CreateShipDto>
    {
        private readonly IRepositoryCenter _repositoryCenter;

        public CreateShipHandler(IRepositoryCenter repositoryCenter)
        {
            _repositoryCenter = repositoryCenter;
        }

        public async Task<CreateShipDto> Handle(CreateShipCommand request, CancellationToken cancellationToken)
        {
            var ship = request.CreateShipEntity();

            var result = await _repositoryCenter.ShipRepo.Add(ship);
            await _repositoryCenter.CommitAsync();

            return new CreateShipDto(result.Id);
        }
    }
}
