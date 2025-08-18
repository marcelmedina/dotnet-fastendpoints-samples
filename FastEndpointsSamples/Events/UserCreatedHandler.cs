using FastEndpoints;

namespace FastEndpointsSamples.Events
{
    public class UserCreatedHandler : IEventHandler<UserCreatedEvent>
    {
        private readonly ILogger _logger;

        public UserCreatedHandler(ILogger<UserCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(UserCreatedEvent eventModel, CancellationToken ct)
        {
            _logger.LogInformation($"user created event received for:[{eventModel.FirstName}]");
            return Task.CompletedTask;
        }
    }
}
