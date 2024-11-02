// -----------------------------------------------------------------------
// <copyright file="UpdateEmailMessageRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture]
internal sealed class UpdateEmailMessageRequestTests
{
    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly([Values] bool isRead)
    {
        var request = new UpdateEmailMessageRequest(isRead);

        request.IsRead.Should().Be(isRead);
    }
}
