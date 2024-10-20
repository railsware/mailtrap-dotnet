// -----------------------------------------------------------------------
// <copyright file="StringEnumJsonConverterTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Converters;


[TestFixture]
internal sealed class StringEnumJsonConverterTests
{
    private readonly StringEnumJsonConverter<SpecifierType> _converter = new();
    private readonly JsonSerializerOptions _options = MailtrapJsonSerializerOptions.Default;


    [Test]
    public void Read_ShouldReadAndConvert_WhenTokenIsValidString()
    {
        _converter
            .Read(SpecifierType.None.ToString().Quoted(), _options)
            .Should()
            .Be(SpecifierType.None);

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

    [Test]
    public void Write_ShouldWrite_WhenValueIsValid()
    {
        var converter = new StringEnumJsonConverter<AccountResourceType>();
        converter
            .Write(AccountResourceType.None, _options)
            .Should()
            .Be(AccountResourceType.None.ToString().Quoted());

        converter
            .Write(AccountResourceType.Account, _options)
            .Should()
            .Be(AccountResourceType.Account.ToString().Quoted());

        converter
            .Write(AccountResourceType.Billing, _options)
            .Should()
            .Be(AccountResourceType.Billing.ToString().Quoted());

        converter
            .Write(AccountResourceType.Project, _options)
            .Should()
            .Be(AccountResourceType.Project.ToString().Quoted());

        converter
            .Write(AccountResourceType.Inbox, _options)
            .Should()
            .Be(AccountResourceType.Inbox.ToString().Quoted());

        converter
            .Write(AccountResourceType.SendingDomain, _options)
            .Should()
            .Be(AccountResourceType.SendingDomain.ToString().Quoted());

        AccountResourceType? resourceType = null;
        converter
            .Write(resourceType!, _options)
            .Should()
            .Be("null");
    }
}
