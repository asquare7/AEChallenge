using AE.Domains.Ships.Handlers;
using Moq;
using AE.Repositories.Base;
using AE.Repositories.EntityRepoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AE.Tests.Base
{
    public class TestBase
    {
        protected readonly Mock<IRepositoryCenter> _mockRepositoryCenter;
        protected readonly Mock<IShipRepository> _mockShipRepo;
        protected readonly Mock<IPortRepository> _mockPortRepo;
        protected readonly GetNearestPortHandler _handler;
        public TestBase()
        {
            _mockRepositoryCenter = new Mock<IRepositoryCenter>();
            _mockShipRepo = new Mock<IShipRepository>();
            _mockPortRepo = new Mock<IPortRepository>();
            _mockRepositoryCenter.Setup(rc => rc.ShipRepo).Returns(_mockShipRepo.Object);
            _mockRepositoryCenter.Setup(rc => rc.PortRepo).Returns(_mockPortRepo.Object);
            _handler = new GetNearestPortHandler(_mockRepositoryCenter.Object);
        }
    }
}
