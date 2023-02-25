using System.Globalization;

namespace Eliseev.Immutable.Tests.Samples
{
    internal class Sample
    {
        public int IntValue { get; set; }

        public string StringValue { get; set; }

        public Sample InnerSample { get; set; }

        public SampleRecord Record { get; set; }
    }
}
