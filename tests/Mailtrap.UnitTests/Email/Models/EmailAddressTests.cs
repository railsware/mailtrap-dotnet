// -----------------------------------------------------------------------
// <copyright file="EmailAddressTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Email.Models;


[TestFixture]
internal sealed class EmailAddressTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenEmailIsNull()
    {
        var act = () => new EmailAddress(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenEmailIsEmptyString()
    {
        var act = () => new EmailAddress(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldAssignPropertiesCorrectly()
    {
        var email = "john.doe@gmail.com";
        var displayName = "John Doe";

        var address = new EmailAddress(email, displayName);

        address.Email.Should().Be(email);
        address.DisplayName.Should().Be(displayName);
    }

    [Test]
    public void Constructor_ShouldInitializeDisplayNameToNull_WhenNotSpecified()
    {
        var email = "john.doe@gmail.com";

        var address = new EmailAddress(email);

        address.Email.Should().Be(email);
        address.DisplayName.Should().BeNull();
    }

    [Test]
    public void ShouldSerializeCorrectly()
    {
        var email = "john.doe@gmail.com";
        var displayName = "John Doe";

        var address = new EmailAddress(email, displayName);

        var serialized = JsonSerializer.Serialize(address, MailtrapJsonSerializerOptions.NotIndented);

        // TODO: Find more stable way to assert JSON serialization.
        serialized.Should().Be(
        "{" +
            "email".Quoted() + ":" + email.Quoted() + "," +
            "name".Quoted() + ":" + displayName.Quoted() +
        "}");

        var deserialized = JsonSerializer.Deserialize<EmailAddress>(serialized, MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(address);
    }
}
