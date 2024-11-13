// -----------------------------------------------------------------------
// <copyright file="SpecifierTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.AccountAccesses.Models;


[TestFixture]
internal sealed class SpecifierTests
{
    [Test]
    public async Task Deserialize_User()
    {
        var serialized = await Path.Combine("AccountAccesses", "TestData", "Specifier_User.json").ReadTestJson();

        var deserialized = JsonSerializer.Deserialize<Specifier>(serialized, MailtrapJsonSerializerOptions.Default);

        deserialized.Should()
            .NotBeNull().And
            .Match<Specifier>(s =>
                s.Id == 0 &&
                s.Name == "John Doe" &&
                s.Email == "user@example.com" &&
                s.TwoFactorAuth == true &&
                s.Token == null
            );
    }

    [Test]
    public async Task Deserialize_Invite()
    {
        var serialized = await Path.Combine("AccountAccesses", "TestData", "Specifier_Invite.json").ReadTestJson();

        var deserialized = JsonSerializer.Deserialize<Specifier>(serialized, MailtrapJsonSerializerOptions.Default);

        deserialized.Should()
            .NotBeNull().And
            .Match<Specifier>(s =>
                s.Id == 2 &&
                s.Name == null &&
                s.Email == "invited.user@example.com" &&
                s.TwoFactorAuth == null
            );
    }

    [Test]
    public async Task Deserialize_Token()
    {
        var serialized = await Path.Combine("AccountAccesses", "TestData", "Specifier_Token.json").ReadTestJson();

        var deserialized = JsonSerializer.Deserialize<Specifier>(serialized, MailtrapJsonSerializerOptions.Default);

        deserialized.Should()
            .NotBeNull().And
            .Match<Specifier>(s =>
                s.Id == 42 &&
                s.Name == "Token" &&
                s.Email == null &&
                s.TwoFactorAuth == null &&
                s.AuthorName == "Author" &&
                s.Token == "token" &&
                s.ExpiresAt == new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero)
            );
    }
}
