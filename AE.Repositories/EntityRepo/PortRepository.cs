using AE.Models.Data;
using AE.Models.Models;
using Microsoft.Extensions.Logging;
using AE.Repositories.Dto;
using AE.Repositories.EntityRepoBase;

namespace AE.Repositories.EntityRepo
{
    public class PortRepository : GenericRepository<Port>, IPortRepository
    {
        public PortRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
            
        }

        public Task<GetShipPointRepoDto> GetNearestPointAsync(double lat, double lng)
        {
            var query = Task.Run(() =>
            {
                return dbSet.AsEnumerable()
                .OrderBy(p => CalculateDistance(lat, lng, p.Latitude, p.Longitude))
                .Select(p => new GetShipPointRepoDto
                {
                    PortId = p.Id,
                    PortName = p.Name,
                    PortLat = p.Latitude,
                    PortLong = p.Longitude,
                    DistanceKMs = CalculateDistance(lat, lng, p.Latitude, p.Longitude)
                }).FirstOrDefault();
            });

            return query;
        }

        private double CalculateDistance(double slat, double slng, double tlat, double tlng)
        {
            const int EarthRotation = 6371;

            return EarthRotation * Math.Acos(
                                   Math.Cos(slat * Math.PI / 180) * Math.Cos(tlat * Math.PI / 180) *
                                   Math.Cos((tlng * Math.PI / 180) - (slng * Math.PI / 180)) +
                                   Math.Sin(slat * Math.PI / 180) * Math.Sin(tlat * Math.PI / 180)
                                 );
        }
    }
}
