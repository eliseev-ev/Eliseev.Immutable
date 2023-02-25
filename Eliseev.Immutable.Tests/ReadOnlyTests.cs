using Eliseev.Immutable.Tests.Samples;

namespace Eliseev.Immutable.Tests
{
    public class ReadOnlyTests
    {

        private Sample sample;

        [SetUp]
        public void Setup()
        {
            sample = new Sample()
            {
                IntValue = 11,
                StringValue = "hello",
                InnerSample = new Sample()
                {
                    StringValue = "hello 2",
                    IntValue = 22,
                },
                Record = new SampleRecord
                {
                    StringValue = "hello",
                }
            };
        }

        [Test]
        public void ReadOnlyGetValuesTests()
        {
            // Arrange
            // Act
            var readonlySample = ReadOnly<Sample>.Create(sample);

            // Assert
            var intValue = readonlySample.GetValue(x => x.IntValue);
            Assert.That(intValue, Is.EqualTo(sample.IntValue));

            var stringValue = readonlySample.GetValue(x => x.StringValue);
            Assert.That(stringValue, Is.EqualTo(sample.StringValue));

            var innerSample = readonlySample.GetRefValue(x => x.InnerSample);
            Assert.That(innerSample, Is.TypeOf<ReadOnly<Sample>>());

            var stringValueLength = readonlySample.GetValue(x => x.StringValue.Length);
            Assert.That(stringValueLength, Is.EqualTo(sample.StringValue.Length));

            var record = readonlySample.GetRefValue(x => x.Record);
            Assert.That(record, Is.TypeOf<ReadOnly<SampleRecord>>());

            var list = readonlySample.GetRefValue(x => x.Samples);
            Assert.That(list, Is.TypeOf<ReadOnly<List<Sample>>>());
        }
    }
}