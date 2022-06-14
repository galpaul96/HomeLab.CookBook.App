using HomeLab.Domain.Interfaces.Services;
using HomeLab.Domain.Settings;
using HomeLab.Ecosystem.Exceptions;
using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HomeLab.Ecosystem.Services
{
    internal class ApiClient : IApiClient
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<ApiClient> _logger;
        private readonly IdentitySettings _identitySettings;

        private static TokenResponse? _token;
        private static DateTime _expirationDate;
        private Task<TokenResponse> Token
        {
            get
            {
                if (_token == null || _expirationDate <= DateTime.UtcNow.AddMinutes(-5))
                {
                    return GetToken();
                }
                return Task.FromResult(_token);
            }
        }

        public ApiClient(IHttpClientFactory httpClient, ILogger<ApiClient> logger, IOptions<IdentitySettings> identitySettings)
        {
            _httpClient = httpClient;
            _logger = logger;
            _identitySettings = identitySettings.Value;
        }

        private async Task<TokenResponse> GetToken()
        {
            var discoveryDocumentPolicy = RetryPolicyFactory.CreateRetryPolicy<DiscoveryDocumentResponse>();
            using var httpClient = _httpClient.CreateClient();//await CreateAsync(_identitySettings.Authority));

            var discoveryDocument = await discoveryDocumentPolicy.ExecuteAsync(async () =>
            {
                try
                {
                    var disco = await httpClient.GetDiscoveryDocumentAsync(_identitySettings.Authority);
                    return disco;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            });

            if (discoveryDocument.IsError)
            {
                _logger.LogError("Error getting discovery document: {0}", discoveryDocument.Error);
                throw new Exception("Error getting discovery document.");
            }
            var retryPolicy = RetryPolicyFactory.CreateRetryPolicy<TokenResponse>();

            var tokenResponse = await retryPolicy.ExecuteAsync(async () =>
            {

                var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = _identitySettings.ClientId,
                    ClientSecret = _identitySettings.ClientSecret,
                    GrantType = "client_credentials",
                    Scope = string.Join(" ", _identitySettings.Scopes)
                });

                return tokenResponse;
            });

            if (tokenResponse.IsError)
            {
                _logger.LogError("Error getting token: {0}", tokenResponse.Error);
                throw new Exception("Error getting token.");
            }

            _token = tokenResponse;
            _expirationDate = DateTime.UtcNow.AddMinutes(tokenResponse.ExpiresIn);

            return tokenResponse;
        }

        public async Task<T> GetAsync<T>(string baseUrl, string relativePath)
        {
            var retryPolicy = RetryPolicyFactory.CreateRetryPolicy<T>();

            return await retryPolicy.ExecuteAsync(async () =>
            {
                var httpClient = await CreateAsync(baseUrl);
                var response = await httpClient.GetAsync(relativePath);
                if (!response.IsSuccessStatusCode)
                {
                    throw await HandleResponse(response);
                }

                var contentAsString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(contentAsString!)!;
            });
        }
        public async Task<T> PostAsync<T>(string baseUrl, string relativePath, object requestContent)
        {
            var retryPolicy = RetryPolicyFactory.CreateRetryPolicy<T>();
            var content = new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await retryPolicy.ExecuteAsync(async () =>
            {
                var httpClient = await CreateAsync(baseUrl);
                var response = await httpClient.PostAsync(relativePath, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw await HandleResponse(response);
                }

                string contentAsString = await response.Content.ReadAsStringAsync();

                string rawContentLogMessage = $"Request succeeded for {response.RequestMessage!.Method} {response.RequestMessage.RequestUri} with HttpStatusCode {response.StatusCode} and Response: {contentAsString}";
                _logger.LogWarning(rawContentLogMessage);

                return JsonConvert.DeserializeObject<T>(contentAsString!)!;
            });
        }

        public async Task DeleteAsync(string baseUrl, string relativePath, Guid id)
        {
            var retryPolicy = RetryPolicyFactory.CreateRetryPolicy();

            await retryPolicy.ExecuteAsync(async () =>
            {
                var httpClient = await CreateAsync(baseUrl);
                var response = await httpClient.DeleteAsync($"{relativePath}/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    throw await HandleResponse(response);
                }
            });
        }

        private async Task<Exception> HandleResponse(HttpResponseMessage restResponse)
        {
            var contentAsString = restResponse.Content != null ? await restResponse.Content.ReadAsStringAsync() : null;
            string errorMessage = $"Request failed {restResponse.RequestMessage!.RequestUri} {restResponse.RequestMessage.Method} HttpStatusCode:{restResponse.StatusCode} Response:{contentAsString}";
            _logger.Log(LogLevel.Error, errorMessage);

            if (restResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new NotFoundRestRequestException(errorMessage);
            }

            if (restResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                try
                {
                    BadRequestErrorCollection badRequestResponse = JsonConvert.DeserializeObject<BadRequestErrorCollection>(contentAsString!)!;
                    throw new BadRequestException(errorMessage) { Errors = badRequestResponse!.Errors };
                }
                catch (JsonSerializationException)
                {
                    throw new BadRequestException(errorMessage);
                }
            }

            return new RestRequestException(errorMessage, restResponse.StatusCode);
        }

        private Task<HttpClient> CreateAsync(string baseUrl)
        {
            var client = _httpClient.CreateClient("default");
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.SetBearerToken(Token.Result.AccessToken);
            return Task.FromResult(client);
        }
    }
}