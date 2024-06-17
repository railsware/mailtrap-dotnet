// -----------------------------------------------------------------------
// <copyright file="MessageIdTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Tests.Email.Models;


[TestFixture]
internal sealed class MessageIdTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNullValue()
    {
        var act = () => new MessageId(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldNotThrowException_WhenEmptyValue()
    {
        var act = () => new MessageId(string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void Empty_ShouldHaveProperValues()
    {
        MessageId.Empty.ToString().Should().BeEmpty();
    }

    [Test]
    public void Constructor_ShouldProduceValidEmptyObject_WhenEmptyValueIsUsed()
    {
        var messageId = new MessageId(string.Empty);

        messageId.ToString().Should().BeEmpty();
    }

    [TestCase("", "", ExpectedResult = true)]
    [TestCase("", "312", ExpectedResult = false)]
    [TestCase("", "123", ExpectedResult = false)]
    [TestCase("123", "", ExpectedResult = false)]
    [TestCase("123", "312", ExpectedResult = false)]
    [TestCase("123", "123", ExpectedResult = true)]
    public bool Equals_ShouldWorkCorrectly(string id1, string id2)
    {
        var messageId1 = new MessageId(id1);

        return messageId1.Equals(new MessageId(id2));
    }

    [Test]
    public void Equatable_ShouldWorkCorrectly_WhenEmpty()
    {
        var messageId = new MessageId(string.Empty);

        messageId.Should().Be(MessageId.Empty);
        (messageId == MessageId.Empty).Should().BeTrue();
        (messageId != MessageId.Empty).Should().BeFalse();
        messageId.Equals(MessageId.Empty).Should().BeTrue();
        messageId.GetHashCode().Should().Be(MessageId.Empty.GetHashCode());
    }

    [Test]
    public void Equatable_ShouldWorkCorrectly_WhenNonEmptyAndEqual()
    {
        var id = "123";

        var messageId1 = new MessageId(id);
        var messageId2 = new MessageId(id);

        messageId2.Should().Be(messageId1);
        (messageId1 == messageId2).Should().BeTrue();
        (messageId1 != messageId2).Should().BeFalse();
        messageId2.Equals(messageId1).Should().BeTrue();
        messageId2.GetHashCode().Should().Be(messageId1.GetHashCode());
        messageId2.ToString().Should().Be(id);
        messageId2.ToString().Should().Be(messageId1.ToString());
    }

    [Test]
    public void Equatable_ShouldWorkCorrectly_WhenNonEmptyAndNotEqual()
    {
        var messageId1 = new MessageId("123");
        var messageId2 = new MessageId("321");

        messageId1.ToString().Should().Be("123");
        messageId2.ToString().Should().Be("321");

        messageId2.Should().NotBe(messageId1);
        (messageId1 == messageId2).Should().BeFalse();
        (messageId1 != messageId2).Should().BeTrue();
        messageId2.Equals(messageId1).Should().BeFalse();
        messageId2.GetHashCode().Should().NotBe(messageId1.GetHashCode());
    }

    [Test]
    public void ShouldSerializeCorrectly()
    {
        var id = "123";

        var messageId = new MessageId(id);

        var serialized = JsonSerializer.Serialize(messageId, MailtrapJsonSerializerOptions.NotIndented);

        serialized.Should().Be(id.Quoted());

        var deserialized = JsonSerializer.Deserialize<MessageId>(serialized, MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(messageId);
    }
}
