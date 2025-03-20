namespace Mailtrap.UnitTests.Core.Converters;


[TestFixture]
internal sealed class StringEnumJsonConverterTests
{
    private readonly StringEnumJsonConverter<DispositionType> _converter = new();
    private readonly JsonSerializerOptions _options = MailtrapJsonSerializerOptions.Default;


    [Test]
    public void Read_ShouldReadAndConvert_WhenTokenIsValidString()
    {
        _converter
            .Read("null", _options)
            .Should()
            .Be(DispositionType.None);

        _converter
            .Read(string.Empty.AddDoubleQuote(), _options)
            .Should()
            .Be(DispositionType.None);

        _converter
            .Read(DispositionType.None.ToString().AddDoubleQuote(), _options)
            .Should()
            .Be(DispositionType.None);

        _converter
            .Read(DispositionType.Attachment.ToString().AddDoubleQuote(), _options)
            .Should()
            .Be(DispositionType.Attachment);

        _converter
            .Read(DispositionType.Inline.ToString().AddDoubleQuote(), _options)
            .Should()
            .Be(DispositionType.Inline);

        _converter
            .Read("abracadabra".AddDoubleQuote(), _options)
            .Should()
            .Be(DispositionType.Unknown);
    }

    [Test]
    public void Read_ShouldThrowJsonException_WhenTokenIsOfUnsupportedType()
    {
        var act = () => _converter.Read("[]", _options);

        act.Should().Throw<JsonException>();
    }

    [Test]
    public void Write_ShouldWrite_WhenValueIsValid()
    {
        var converter = new StringEnumJsonConverter<DispositionType>();
        converter
            .Write(DispositionType.None, _options)
            .Should()
            .Be(DispositionType.None.ToString().AddDoubleQuote());

        converter
            .Write(DispositionType.Attachment, _options)
            .Should()
            .Be(DispositionType.Attachment.ToString().AddDoubleQuote());

        converter
            .Write(DispositionType.Inline, _options)
            .Should()
            .Be(DispositionType.Inline.ToString().AddDoubleQuote());

        DispositionType? enumType = null;
        converter
            .Write(enumType!, _options)
            .Should()
            .Be("null");
    }
}
