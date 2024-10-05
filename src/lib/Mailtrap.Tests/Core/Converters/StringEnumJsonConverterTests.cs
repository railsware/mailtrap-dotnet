// -----------------------------------------------------------------------
// <copyright file="StringEnumJsonConverterTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Core.Converters;


[TestFixture]
internal sealed class StringEnumJsonConverterTests
{
    private readonly StringEnumJsonConverter<SpecifierType> _converter = new();
    private readonly JsonSerializerOptions _options = MailtrapJsonSerializerOptions.Default;


    [Test]
    public void Read_ShouldReadAndConvert_WhenTokenIsValidString()
    {
        _converter
            .Read(SpecifierType.Empty.ToString().Quoted(), _options)
            .Should()
            .Be(SpecifierType.Empty);

        _converter
            .Read(SpecifierType.User.ToString().Quoted(), _options)
            .Should()
            .Be(SpecifierType.User);

        _converter
            .Read(SpecifierType.Invite.ToString().Quoted(), _options)
            .Should()
            .Be(SpecifierType.Invite);

        _converter
            .Read(SpecifierType.ApiToken.ToString().Quoted(), _options)
            .Should()
            .Be(SpecifierType.ApiToken);
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
}
