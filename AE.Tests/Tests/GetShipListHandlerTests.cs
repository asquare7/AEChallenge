using AE.Domains.Ships.Handlers;
using AE.Domains.Ships.Queries;
using Moq;
using AE.Models.Models;
using AE.Tests.Base;
using Xunit;

namespace AE.Tests.Tests
{
    public class GetShipListHandlerTests : TestBase
    {
        [Fact]
        public async Task Handle_ReturnsListOfGetShipByIdDto_WhenShipExists()
        {
            var ships = new List<Ship>
        {
            new Ship { Id = 1, Name = "Ship 1" },
            new Ship { Id = 2, Name = "Ship 2" },
            new Ship { Id = 3, Name = "Ship 3" }
        };
            var expectedDtoList = ships.MapToDto();

            _mockRepositoryCenter.Setup(sr => sr.ShipRepo.All()).ReturnsAsync((IEnumerable<Ship>)ships);

            var handler = new GetShipListHandler(_mockRepositoryCenter.Object);
            var result = await handler.Handle(new GetShipListQuery(), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(expectedDtoList.Count, result.Count);
            for (int i = 0; i < expectedDtoList.Count; i++)
            {
                Assert.Equal(expectedDtoList[i].Id, result[i].Id);
                Assert.Equal(expectedDtoList[i].Name, result[i].Name);
            }
        }

        [Fact]
        public async Task Handle_ReturnsNull_WhenShipDoesNotExist()
        {
            _mockRepositoryCenter.Setup(sr => sr.ShipRepo.All()).ReturnsAsync((IEnumerable<Ship>)null);

            var handler = new GetShipListHandler(_mockRepositoryCenter.Object);
            var result = await handler.Handle(new GetShipListQuery(), CancellationToken.None);

            Assert.Null(result);
        }
    }
}
