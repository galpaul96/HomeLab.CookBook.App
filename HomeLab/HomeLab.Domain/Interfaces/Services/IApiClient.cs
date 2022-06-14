namespace HomeLab.Domain.Interfaces.Services
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string baseUrl, string relativePath);
        Task<T> PostAsync<T>(string baseUrl, string relativePath, object requestContent);
        Task DeleteAsync(string baseUrl, string relativePath, Guid id);
    }
}
