// -----------------------------------------------------------------------
// <copyright file="StringEnumJsonConverterTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Converters;


[TestFixture]
internal sealed class StringEnumJsonConverterTests
{
    private readonly StringEnumJsonConverter<DispositionType> _converter = new();
    private readonly JsonSerializerOptions _options = MailtrapJsonSerializerOptions.Default;


    [Test]
    public void Read_ShouldReadAndConvert_WhenTokenIsValidString()
    {
        _converter
            .Read(DispositionType.None.ToString().Quoted(), _options)
            .Should()
            .Be(DispositionType.None);

        _converter
            .Read(DispositionType.Attachment.ToString().Quoted(), _options)
            .Should()
            .Be(DispositionType.Attachment);

        _converter
            .Read(DispositionType.Inline.ToString().Quoted(), _options)
            .Should()
            .Be(DispositionType.Inline);
    }

    [Test]
    public void Read_ShouldThrowJsonException_WhenTokenIsNull()
    {
        var act = () => _converter.Read("null", _options);

        act.Should().Throw<JsonException>();
    }

    [Test]
    public void Read_ShouldThrowJsonException_WhenTokenIsOfUnsupportedType()
    {
        var act = () => _converter.Read("[]", _options);

        act.Should().Throw<JsonException>();
    }

    [Test]
    public void Read_ShouldThrowJsonException_WhenTokenIsUnsupportedValue()
    {
        var act = () => _converter.Read("abracadabra".Quoted(), _options);

        act.Should().Throw<JsonException>();
    }

    [Test]
    public void Write_ShouldWrite_WhenValueIsValid()
    {
        var converter = new StringEnumJsonConverter<DispositionType>();
        converter
            .Write(DispositionType.None, _options)
            .Should()
            .Be(DispositionType.None.ToString().Quoted());

        converter
            .Write(DispositionType.Attachment, _options)
            .Should()
            .Be(DispositionType.Attachment.ToString().Quoted());

        converter
            .Write(DispositionType.Inline, _options)
            .Should()
            .Be(DispositionType.Inline.ToString().Quoted());

        DispositionType? resourceType = null;
        converter
            .Write(resourceType!, _options)
            .Should()
            .Be("null");
    }
}
