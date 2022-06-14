using HomeLab.Domain.Interfaces.Repositories;
using HomeLab.Domain.Interfaces.Services;

namespace HomeLab.Services.Services
{
    internal class HealthChecksService : IHealthChecksService
    {
        private readonly IRepository _repository;

        public HealthChecksService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> EfCanConnect()
        {
            return await _repository.HealthCheck();
        }
    }
}
