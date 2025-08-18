using System.Diagnostics;

namespace FastEndpointsSamples.Models
{
    public class MyStateBag
    {
        private readonly Stopwatch _sw = new();

        public bool IsValidAge { get; set; }
        public string Status { get; set; }
        public long DurationMillis => _sw.ElapsedMilliseconds;

        public MyStateBag() => _sw.Start();
    }
}
