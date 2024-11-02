// -----------------------------------------------------------------------
// <copyright file="StringEnumJsonConverterFactoryTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Mailtrap.UnitTests.TestExtensions;

namespace Mailtrap.UnitTests.Converters;


[TestFixture]
internal sealed class StringEnumJsonConverterFactoryTests
{
    private readonly JsonSerializerOptions _options = MailtrapJsonSerializerOptions.Default;


    [Test]
    public void Serialize_ShouldUseConverterFactory()
    {
        JsonSerializer
            .Serialize(SpecifierType.User, _options)
            .Should()
            .Be(SpecifierType.User.ToString().Quoted());

        JsonSerializer
            .Serialize(AccountResourceType.Billing, _options)
            .Should()
            .Be(AccountResourceType.Billing.ToString().Quoted());
    }

    [Test]
    public void Deserialize_ShouldUseConverterFactory()
    {
        JsonSerializer
            .Deserialize<SpecifierType>(SpecifierType.Invite.ToString().Quoted(), _options)
            .Should()
            .Be(SpecifierType.Invite);

        JsonSerializer
            .Deserialize<AccountResourceType>(AccountResourceType.Project.ToString().Quoted(), _options)
            .Should()
            .Be(AccountResourceType.Project);
    }

    [Test]
    public void Deserialize_ShouldThrow_WhenInvalidTypeSpecified()
    {
        var act1 = () => JsonSerializer
            .Deserialize<bool>(SpecifierType.Invite.ToString().Quoted(), _options);

        act1.Should().Throw<JsonException>();

        var act2 = () => JsonSerializer
            .Deserialize<SpecifierType>(AccountResourceType.Project.ToString().Quoted(), _options);

        act2.Should().Throw<JsonException>();
    }
}
