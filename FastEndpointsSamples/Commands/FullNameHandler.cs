using FastEndpoints;

namespace FastEndpointsSamples.Commands
{
    public class FullNameHandler : ICommandHandler<GetFullName, string>
    {
        public Task<string> ExecuteAsync(GetFullName command, CancellationToken ct)
        {
            var result = command.FirstName + " " + command.LastName;
            return Task.FromResult(result);
        }
    }
}
