using HomeLab.Ecosystem.Exceptions;
using Polly;
using System.Net;

namespace HomeLab.Ecosystem.Services
{
    internal static class RetryPolicyFactory
    {
        private const int RetryCount = 3;

        public static AsyncPolicy<TResult> CreateRetryPolicy<TResult>()
        {
            var retryPolicy = Policy<TResult>
                .Handle<RestRequestException>(CanRetry)
                .WaitAndRetryAsync(RetryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .WrapAsync(CircuitBreaker.Create());

            return retryPolicy;
        }
        public static AsyncPolicy CreateRetryPolicy()
        {
            var retryPolicy = Policy
                .Handle<RestRequestException>(CanRetry)
                .WaitAndRetryAsync(RetryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .WrapAsync(CircuitBreaker.Create());

            return retryPolicy;
        }

        private static bool CanRetry(RestRequestException exception)
        {
            return exception.StatusCode == HttpStatusCode.RequestTimeout ||
                   exception.StatusCode >= HttpStatusCode.InternalServerError &&
                   exception.StatusCode != HttpStatusCode.NotImplemented &&
                   exception.StatusCode != HttpStatusCode.HttpVersionNotSupported;
        }
    }
}
