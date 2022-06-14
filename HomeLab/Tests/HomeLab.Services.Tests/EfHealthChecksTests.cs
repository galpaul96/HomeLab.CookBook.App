using HomeLab.Domain.Interfaces.Repositories;
using HomeLab.Services.Services;
using Moq;

namespace HomeLab.Services.Tests
{
    public class EfHealthChecksTests
    {
        private HealthChecksService service;
        private Mock<IRepository> _repositoryMock;
        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository>();

            service = new HealthChecksService(_repositoryMock.Object);
        }

        [Test]
        public async Task Test1()
        {
            _repositoryMock.Setup(x => x.HealthCheck()).ReturnsAsync(true);

            Assert.True(await service.EfCanConnect());
        }
    }
}