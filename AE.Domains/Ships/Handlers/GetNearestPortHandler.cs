using MediatR;
using AE.Domains.Ships.Dto;
using AE.Domains.Ships.Queries;
using AE.Repositories.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AE.Domains.Ships.Handlers
{
    public class GetNearestPortHandler : IRequestHandler<GetNearestPortByShipIDQuery, GetNearestPortByShipIdDto>
    {
        private readonly IRepositoryCenter repositoryCenter;

        public GetNearestPortHandler(IRepositoryCenter repositoryCenter)
        {
            this.repositoryCenter = repositoryCenter;
        }

        public async Task<GetNearestPortByShipIdDto> Handle(GetNearestPortByShipIDQuery query,
            CancellationToken cancellationToken)
        {
            var shipEntity = await repositoryCenter.ShipRepo.GetById(query.Id);
            if (shipEntity == null)
                return null;

            var nearestPointDto =
                await repositoryCenter.PortRepo.GetNearestPointAsync(shipEntity.Latitude, shipEntity.Longitude);

            double timeEstimateHours = CalculateTimeEstimate(nearestPointDto.DistanceKMs, shipEntity.Velocity);

            return new GetNearestPortByShipIdDto()
            {
                PortDetails = new PortDto
                {
                    Id = nearestPointDto.PortId,
                    Name = nearestPointDto.PortName,
                    Latitude = nearestPointDto.PortLat,
                    Longitude = nearestPointDto.PortLong
                },
                DistanceKMs = nearestPointDto.DistanceKMs.RoundOffToTwoDecimalPoints(),
                EstimatedArraivalTimeHours = timeEstimateHours.RoundOffToTwoDecimalPoints()
            };
        }

        private double CalculateTimeEstimate(double distance, decimal velocity)
        {
            return Convert.ToDouble(distance / Convert.ToDouble(velocity));
        }
    }
}