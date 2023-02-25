using System.Globalization;

namespace Eliseev.Immutable.Tests.Samples
{
    internal record SampleRecord
    {
        public int IntValue { get; set; }

        public string StringValue { get; set; }

        public Sample InnerSample { get; set; }
    }
}
