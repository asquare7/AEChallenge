using AE.Domains.Ships.Commands;
using AE.Domains.Ships.Dto;
using AE.Domains.Ships.Handlers;
using Moq;
using AE.Models.Models;
using AE.Tests.Base;
using Xunit;

namespace AE.Tests.Tests
{
    public class UpdateShipHandlerTests : TestBase
    {
        [Fact]
        public async Task Handle_ReturnsUpdatedShipVelocityDto_WhenShipExists()
        {
            var shipId = 1;
            var command = new UpdateShipCommand(shipId, 20);
            var shipDetails = new Ship { Id = shipId, Velocity = 10m };
            var updatedShipDetails = new Ship { Id = shipId, Velocity = 20m };
            var expectedDto = new UpdateShipVelocityDto { Id = shipId, Velocity = 20m };

            _mockRepositoryCenter.Setup(sr => sr.ShipRepo.GetById(shipId)).ReturnsAsync(shipDetails);
            _mockRepositoryCenter.Setup(sr => sr.ShipRepo.Update(It.IsAny<Ship>())).ReturnsAsync(updatedShipDetails);

            var handler = new UpdateShipHandler(_mockRepositoryCenter.Object);
            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.Velocity, result.Velocity);
            _mockRepositoryCenter.Verify(sr => sr.ShipRepo.Update(It.IsAny<Ship>()), Times.Once);
            _mockRepositoryCenter.Verify(rc => rc.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_ReturnsDefault_WhenShipDoesNotExist()
        {
            var shipId = 1;
            var command = new UpdateShipCommand (shipId, 20m);

            _mockRepositoryCenter.Setup(sr => sr.ShipRepo.GetById(shipId)).ReturnsAsync((Ship)null);

            var handler = new UpdateShipHandler(_mockRepositoryCenter.Object);
            var result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal(default(UpdateShipVelocityDto), result);
            _mockRepositoryCenter.Verify(sr => sr.ShipRepo.Update(It.IsAny<Ship>()), Times.Never);
            _mockRepositoryCenter.Verify(rc => rc.CommitAsync(), Times.Never);
        }
    }
}
