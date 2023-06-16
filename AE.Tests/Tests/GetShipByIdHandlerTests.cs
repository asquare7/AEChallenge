using AE.Domains.Ships.Handlers;
using AE.Domains.Ships.Queries;
using AE.Models.Models;
using AE.Tests.Base;
using Moq;
using Xunit;

namespace AE.Tests.Tests
{
    public class GetShipByIdHandlerTests : TestBase
    {
        [Fact]
        public async Task Handle_ReturnsGetShipByIdDto_WhenShipExists()
        {
            var shipId = 1;
            var query = new GetShipByIdQuery { Id = shipId };
            var ship = new Ship { Id = shipId, Name = "Ship 1" };
            var expectedDto = ship.MapToDto();

            _mockRepositoryCenter.Setup(sr => sr.ShipRepo.GetById(shipId)).ReturnsAsync(new Ship { Id = shipId });

            var handler = new GetShipByIdHandler(_mockRepositoryCenter.Object);
            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);

        }

        [Fact]
        public async Task Handle_ReturnsNull_WhenShipDoesNotExist()
        {
            var shipId = 1;
            var query = new GetShipByIdQuery { Id = shipId };

            _mockRepositoryCenter.Setup(sr => sr.ShipRepo.GetById(shipId)).ReturnsAsync((Ship)null);

            var handler = new GetShipByIdHandler(_mockRepositoryCenter.Object);
            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Null(result);
        }
    }
}
