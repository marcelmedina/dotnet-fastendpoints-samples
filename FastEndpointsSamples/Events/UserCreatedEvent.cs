namespace FastEndpointsSamples.Events
{
    public class UserCreatedEvent
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
