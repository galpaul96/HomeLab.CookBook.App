namespace HomeLab.Domain.Interfaces.Services
{
    public interface IHealthChecksService
    {
        Task<bool> EfCanConnect();
    }
}
