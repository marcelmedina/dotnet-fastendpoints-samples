using FastEndpoints;

namespace FastEndpointsSamples.Commands
{
    public class GetFullName : ICommand<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
