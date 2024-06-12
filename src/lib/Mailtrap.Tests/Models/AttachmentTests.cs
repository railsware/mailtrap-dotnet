// -----------------------------------------------------------------------
// <copyright file="AttachmentTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Models;


[TestFixture]
internal sealed class AttachmentTests
{
    [Test]
    public void ShouldThrow_WhenEmptyContentProvidedToConstructor()
    {
        var act = () => new Attachment(string.Empty, string.Empty);

        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void ShouldNotThrow_WhenEmptyFileNameProvidedToConstructor()
    {
        var act = () => new Attachment("Test Text", string.Empty);

        act.Should().NotThrow<ArgumentException>();
    }

    [Test]
    public void ShouldNotThrow_WhenDispositionIsSetToNull()
    {
        var act = () => new Attachment("Test Text", string.Empty, null);

        act.Should().NotThrow<ArgumentNullException>();
    }

    [Test]
    public void DispositionShouldDefaultToAttachment_WhenNotSpecified()
    {
        var attachment = new Attachment("Test Text", string.Empty);

        attachment.Disposition.Should().Be(DispositionType.Attachment);
    }

    [Test]
    public void DispositionShouldDefaultToAttachment_WhenIsSetToNullExplicitly()
    {
        var attachment = new Attachment("Test Text", string.Empty, null);

        attachment.Disposition.Should().Be(DispositionType.Attachment);
    }
}
