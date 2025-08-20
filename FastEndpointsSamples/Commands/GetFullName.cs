using FastEndpoints;

namespace FastEndpointsSamples.Commands
{
    public class GetFullName : ICommand<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class FullNameHandler : ICommandHandler<GetFullName, string>
    {
        public Task<string> ExecuteAsync(GetFullName command, CancellationToken ct)
        {
            var result = command.FirstName + " " + command.LastName;
            return Task.FromResult(result);
        }
    }
}
