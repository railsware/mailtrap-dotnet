// -----------------------------------------------------------------------
// <copyright file="RecipientTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Models;


[TestFixture]
internal sealed class EmailPartyTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenEmailIsNull()
    {
        var act = () => new EmailParty(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenEmailIsEmptyString()
    {
        var act = () => new EmailParty(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldAssignPropertiesCorrectly()
    {
        var email = "john.doe@gmail.com";
        var displayName = "John Doe";

        var party = new EmailParty(email, displayName);

        party.EmailAddress.Should().Be(email);
        party.DisplayName.Should().Be(displayName);
    }

    [Test]
    public void Constructor_ShouldInitializeDisplayNameToNull_WhenNotSpecified()
    {
        var email = "john.doe@gmail.com";

        var party = new EmailParty(email);

        party.EmailAddress.Should().Be(email);
        party.DisplayName.Should().BeNull();
    }

    [Test]
    public void ShouldSerializeCorrectly()
    {
        var email = "john.doe@gmail.com";
        var displayName = "John Doe";

        var party = new EmailParty(email, displayName);

        var serialized = JsonSerializer.Serialize(party, GlobalJsonSerializerOptions.NotIndented);

        serialized.Should().Be(
        "{" +
            "\"email\":\"" + email + "\"," +
            "\"name\":\"" + displayName + "\"" +
        "}");

        var deserialized = JsonSerializer.Deserialize<EmailParty>(serialized, GlobalJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(party);
    }
}
