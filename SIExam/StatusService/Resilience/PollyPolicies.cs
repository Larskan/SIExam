using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

namespace StatusService.Resilience;

public static class PollyPolicies
{
    // Retry policy with exponential backoff
    public static IAsyncPolicy<HttpResponseMessage> RetryPolicy => HttpPolicyExtensions
        .HandleTransientHttpError()
        .Or<TimeoutRejectedException>()
        .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
        );
  
    // Circuit breaker policy
    public static IAsyncPolicy<HttpResponseMessage> CircuitBreakerPolicy => HttpPolicyExtensions
        .HandleTransientHttpError()
        .Or<TimeoutRejectedException>()
        .CircuitBreakerAsync(
            handledEventsAllowedBeforeBreaking: 5,
            durationOfBreak: TimeSpan.FromSeconds(30)
        );
    
    // Timeout policy
    public static IAsyncPolicy<HttpResponseMessage> TimeoutPolicy => 
    Policy.TimeoutAsync<HttpResponseMessage>(5); // 5 seconds timeout
}