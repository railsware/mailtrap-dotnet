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
    public void ShouldNotThrowWhenEmptyParameterProvidedToConstructor()
    {
        var act = () => new MessageId(string.Empty);

        act.Should().NotThrow();
    }

    [Test]
    public void ShouldProduceEqualObjectsWhenCreatedFromTheSameValue()
    {
        var id = "123";

        var messageId1 = new MessageId(id);
        var messageId2 = new MessageId(id);

        messageId2.Should().Be(messageId1);
        (messageId1 == messageId2).Should().BeTrue();
        messageId2.GetHashCode().Should().Be(messageId1.GetHashCode());
        messageId2.ToString().Should().Be(messageId1.ToString());
        messageId1.ToString().Should().Be(id);
        messageId2.ToString().Should().Be(id);
    }
}
