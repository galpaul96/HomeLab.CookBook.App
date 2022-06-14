using HomeLab.Ecosystem.Exceptions;
using Polly;
using Polly.CircuitBreaker;
using System.Net;

namespace HomeLab.Ecosystem.Services
{
    internal static class CircuitBreaker
    {
        private const int ThrottlingStatusCode = 429;

        private const int MinimumThroughput = 10;
        private const int DurationOfBreakInSeconds = 20;
        private const int SamplingPeriodInSeconds = 60;

        public static AsyncCircuitBreakerPolicy Create()
        {
            return Policy.Handle<RestRequestException>(x =>
                    x.StatusCode == HttpStatusCode.InternalServerError ||
                    x.StatusCode == (HttpStatusCode)ThrottlingStatusCode ||
                    x.StatusCode == HttpStatusCode.ServiceUnavailable)
                .AdvancedCircuitBreakerAsync(0.7, TimeSpan.FromSeconds(SamplingPeriodInSeconds), MinimumThroughput, TimeSpan.FromSeconds(DurationOfBreakInSeconds));
        }
    }
}
