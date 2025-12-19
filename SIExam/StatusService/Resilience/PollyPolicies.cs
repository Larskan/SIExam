using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

namespace StatusService.Resilience;

public static class PollyPolicies
{
    // Retry policy with exponential backoff
    public static IAsyncPolicy<HttpResponseMessage> RetryPolicy(ILogger logger) => HttpPolicyExtensions
        .HandleTransientHttpError()
        .Or<TimeoutRejectedException>()
        .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), 
        onRetry: (outcome, timespan, retryAttempt, context) =>
        {
            logger.LogWarning($"Retrying... Attempt: {retryAttempt} after {timespan.TotalSeconds} seconds due to: {outcome.Exception?.Message}");
        }
        );
  
    // Circuit breaker policy
    public static IAsyncPolicy<HttpResponseMessage> CircuitBreakerPolicy(ILogger logger) => HttpPolicyExtensions
        .HandleTransientHttpError()
        .Or<TimeoutRejectedException>()
        .CircuitBreakerAsync(
            handledEventsAllowedBeforeBreaking: 5,
            durationOfBreak: TimeSpan.FromSeconds(30),
            onBreak: (outcome, breakDelay) =>
            {
                logger.LogWarning($"Circuit broken! Breaking for {breakDelay.TotalSeconds} seconds due to: {outcome.Exception?.Message}");
            },
            onReset: () => logger.LogWarning("Circuit reset!"),
            onHalfOpen: () => logger.LogWarning("Circuit in half-open state. Testing the waters...")
        );
    
    // Timeout policy
    public static IAsyncPolicy<HttpResponseMessage> TimeoutPolicy(ILogger logger) => 
    Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(5), onTimeoutAsync: (context, timespan, task) =>
    {
        logger.LogWarning($"Request timed out after {timespan.TotalSeconds} seconds.");
        return Task.CompletedTask;
    }); // 5 seconds timeout
}