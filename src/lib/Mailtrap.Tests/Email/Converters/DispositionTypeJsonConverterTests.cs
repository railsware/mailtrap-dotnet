// -----------------------------------------------------------------------
// <copyright file="DispositionTypeJsonConverterTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Tests.Email.Responses;


[TestFixture]
internal sealed class DispositionTypeJsonConverterTests
{
    private readonly DispositionTypeJsonConverter _converter = new();


    [Test]
    public void Read_ShouldReadAndConvert_WhenTokenIsNull()
    {
        _converter
            .Read("null", MailtrapJsonSerializerOptions.NotIndented)
            .Should().BeNull();
    }

    [Test]
    public void Read_ShouldReadAndConvert_WhenTokenIsValidString()
    {
        _converter
            .Read("attachment".Quoted(), MailtrapJsonSerializerOptions.NotIndented)
            .Should().Be(DispositionType.Attachment);

        _converter
            .Read("inline".Quoted(), MailtrapJsonSerializerOptions.NotIndented)
            .Should().Be(DispositionType.Inline);
    }

    [Test]
    public void Read_ShouldThrowJsonException_WhenTokenIsOfUnsupportedType()
    {
        var act = () => _converter.Read("[]", MailtrapJsonSerializerOptions.NotIndented);

        act.Should().Throw<JsonException>();
    }

    [Test]
    public void Read_ShouldThrowJsonException_WhenTokenIsUnsupportedValue()
    {
        var act = () => _converter.Read("hidden".Quoted(), MailtrapJsonSerializerOptions.NotIndented);

        act.Should().Throw<JsonException>();
    }

    [Test]
    public void Read_ShouldThrowJsonException_WhenTokenIsEmptyString()
    {
        var act = () => _converter.Read(string.Empty.Quoted(), MailtrapJsonSerializerOptions.NotIndented);

        act.Should().Throw<JsonException>();
    }

    [Test]
    public void Read_ShouldThrowJsonException_WhenTokenCasingIsIncorrectAndCaseSensitiveOptionEnabled()
    {
        var options = new JsonSerializerOptions(MailtrapJsonSerializerOptions.NotIndented)
        {
            PropertyNameCaseInsensitive = false
        };

        var act = () => _converter.Read("Inline".Quoted(), options);

        act.Should().Throw<JsonException>();
    }

    [Test]
    public void Read_ShouldNotThrowException_WhenTokenCasingIsIncorrectAndCaseSensitiveOptionDisabled()
    {
        var options = new JsonSerializerOptions(MailtrapJsonSerializerOptions.NotIndented)
        {
            PropertyNameCaseInsensitive = true
        };

        var act = () => _converter.Read("Inline".Quoted(), options);

        act.Should().NotThrow();
    }
}
