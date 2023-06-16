using AE.Domains.Ships.Queries;
using AE.Models.Models;
using AE.Tests.Base;
using Moq;
using AE.Repositories.Dto;
using Xunit;

namespace AE.Tests.Tests
{
    public class GetNearestPortHandlerTests : TestBase
    {
        [Fact]
        public async Task Handle_ReturnsNearestPort_WhenShipExists()
        {
            var shipId = 1;
            var ship = new Ship { Id = shipId, Latitude = 0.1, Longitude = 0.2, Velocity = 10m };
            var portDetails = new GetShipPointRepoDto { PortId = 2, PortName = "Test Port", PortLat = 0.3, PortLong = 0.4, DistanceKMs = 4 };

            _mockShipRepo.Setup(sr => sr.GetById(shipId)).ReturnsAsync(ship);
            _mockPortRepo.Setup(pr => pr.GetNearestPointAsync(It.IsAny<double>(), It.IsAny<double>())).ReturnsAsync(portDetails);

            var result = await _handler.Handle(new GetNearestPortByShipIDQuery { Id = shipId }, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(portDetails.PortId, result.PortDetails.Id);
            Assert.Equal(portDetails.PortName, result.PortDetails.Name);
            Assert.Equal(portDetails.PortLat, result.PortDetails.Latitude);
            Assert.Equal(portDetails.PortLong, result.PortDetails.Longitude);
            Assert.Equal(portDetails.DistanceKMs, result.DistanceKMs);
        }
        [Fact]
        public async Task Handle_ReturnsNull_WhenShipDoesNotExist()
        {
            // Arrange
            var shipId = 1;
            _mockShipRepo.Setup(sr => sr.GetById(shipId)).ReturnsAsync((Ship)null);
            // Act
            var result = await _handler.Handle(new GetNearestPortByShipIDQuery { Id = shipId }, CancellationToken.None);
            // Assert
            Assert.Null(result);
        }
    }
}