// -----------------------------------------------------------------------
// <copyright file="MessageIdJsonConverterTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Responses;


[TestFixture]
internal sealed class MessageIdJsonConverterTests
{
    private readonly MessageIdJsonConverter _converter = new();


    [Test]
    public void Read_ShouldReadAndConvert_WhenTokenIsNull()
    {
        _converter
            .Read("null", MailtrapJsonSerializerOptions.NotIndented)
            .Should().Be(MessageId.Empty);
    }

    [Test]
    public void Read_ShouldReadAndConvert_WhenTokenIsEmptyString()
    {
        _converter
            .Read(string.Empty.Quoted(), MailtrapJsonSerializerOptions.NotIndented)
            .Should().Be(MessageId.Empty);
    }

    [Test]
    public void Read_ShouldReadAndConvert_WhenTokenIsValidString()
    {
        var id = "123";

        _converter
            .Read(id.Quoted(), MailtrapJsonSerializerOptions.NotIndented)
            .Should().Be(new MessageId(id));
    }

    [Test]
    public void Read_ShouldThrowJsonException_WhenTokenIsOfUnsupportedType()
    {
        var act = () => _converter.Read("[]", MailtrapJsonSerializerOptions.NotIndented);

        act.Should().Throw<JsonException>();
    }
}
