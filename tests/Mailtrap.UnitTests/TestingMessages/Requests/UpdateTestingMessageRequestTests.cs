// -----------------------------------------------------------------------
// <copyright file="UpdateTestingMessageRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.TestingMessages.Requests;


[TestFixture]
internal sealed class UpdateTestingMessageRequestTests
{
    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly([Values] bool isRead)
    {
        var request = new UpdateTestingMessageRequest(isRead);

        request.IsRead.Should().Be(isRead);
    }
}
