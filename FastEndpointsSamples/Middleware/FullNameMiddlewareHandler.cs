using FastEndpoints;
using FastEndpointsSamples.Commands;

namespace FastEndpointsSamples.Middleware
{
    public class FullNameMiddlewareHandler : ICommandMiddleware<GetFullName, string>
    {
        public Task<string> ExecuteAsync(GetFullName command, CommandDelegate<string> next, CancellationToken ct)
        {
            var result = command.FirstName + " " + command.LastName;
            return Task.FromResult(result);
        }
    }
}
