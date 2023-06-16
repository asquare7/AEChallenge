using AE.Domains.Ships.Commands;
using AE.Domains.Ships.Dto;
using AE.Domains.Ships.Handlers;
using AE.Domains.Ships.Queries;
using AE.Models.Models;
using AE.Tests.Base;
using Moq;
using Xunit;

namespace AE.Tests.Tests
{
    public class CreateShipHandlerTests : TestBase
    {
        [Fact]
        public async Task Handle_ReturnsCreateShipDto_WhenShipIsCreated()
        {
            var createShipCommand = new CreateShipCommand() { Name = "Ship1", Latitude = 10.2,Longitude = 80.20, Velocity = 30 };
            var ship = createShipCommand.CreateShipEntity();

            _mockRepositoryCenter.Setup(rc => rc.ShipRepo.Add(It.IsAny<Ship>())).ReturnsAsync(ship);

            var handler = new CreateShipHandler(_mockRepositoryCenter.Object);
            var result = await handler.Handle(createShipCommand, CancellationToken.None);

            Assert.Equal(typeof(CreateShipDto), result.GetType());
            _mockRepositoryCenter.Verify(rc => rc.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_ThrowsException_WhenShipRepoThrowsException()
        {
            var createShipCommand = new CreateShipCommand();
            var ship = createShipCommand.CreateShipEntity();
            var expectedExceptionMessage = "Failed to add ship to repository.";

            _mockRepositoryCenter.Setup(rc => rc.ShipRepo.Add(It.IsAny<Ship>())).ThrowsAsync(new Exception(expectedExceptionMessage));

            var handler = new CreateShipHandler(_mockRepositoryCenter.Object);
            var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(createShipCommand, CancellationToken.None));

            Assert.Equal(expectedExceptionMessage, exception.Message);
            _mockRepositoryCenter.Verify(rc => rc.CommitAsync(), Times.Never);
        }
    }
}