// -----------------------------------------------------------------------
// <copyright file="DispositionTypeTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Models;


[TestFixture]
internal sealed class DispositionTypeTests
{
    [Test]
    public void PredefinedEnumValuesShouldBeCorrect()
    {
        DispositionType.Inline.ToString().Should().Be("inline");
        DispositionType.Attachment.ToString().Should().Be("attachment");
    }

    [Test]
    public void ShouldSerializeCorrectly_WhenInline()
    {
        var disposition = DispositionType.Inline;

        var serialized = JsonSerializer.Serialize(disposition, MailtrapJsonSerializerOptions.NotIndented);

        serialized.Should().Be(DispositionType.Inline.ToString().Quoted());

        var deserialized = JsonSerializer.Deserialize<DispositionType>(serialized, MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(disposition);
    }

    [Test]
    public void ShouldSerializeCorrectly_WhenAttachment()
    {
        var disposition = DispositionType.Attachment;

        var serialized = JsonSerializer.Serialize(disposition, MailtrapJsonSerializerOptions.NotIndented);

        serialized.Should().Be(DispositionType.Attachment.ToString().Quoted());

        var deserialized = JsonSerializer.Deserialize<DispositionType>(serialized, MailtrapJsonSerializerOptions.NotIndented);

        deserialized.Should().BeEquivalentTo(disposition);
    }
}
