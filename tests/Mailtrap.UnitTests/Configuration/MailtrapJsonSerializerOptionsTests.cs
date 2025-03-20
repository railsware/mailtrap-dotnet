namespace Mailtrap.UnitTests.Configuration;


[TestFixture]
[Explicit("Flaky. Seems like JsonSerializerOptions internal state depends on usage.")]
internal sealed class MailtrapJsonSerializerOptionsTests
{
    [Test]
    public void Default_ShouldContainProperValues()
    {
        var expected = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new StringEnumJsonConverterFactory() }
        };

        MailtrapJsonSerializerOptions.Default.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NotIndented_ShouldContainProperValues()
    {
        var expected = new JsonSerializerOptions(MailtrapJsonSerializerOptions.Default)
        {
            WriteIndented = false
        };

        MailtrapJsonSerializerOptions.NotIndented.Should().BeEquivalentTo(expected);
    }
}
