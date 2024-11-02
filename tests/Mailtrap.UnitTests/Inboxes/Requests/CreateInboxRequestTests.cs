// -----------------------------------------------------------------------
// <copyright file="CreateInboxRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.Inboxes.Requests;


[TestFixture]
internal sealed class CreateInboxRequestTests
{
    private const long ProjectId = 42;
    private const string Name = "Test Inbox";


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsNull()
    {
        var act = () => new CreateInboxRequest(ProjectId, null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsEmpty()
    {
        var act = () => new CreateInboxRequest(ProjectId, string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        var request = new CreateInboxRequest(ProjectId, Name);

        request.ProjectId.Should().Be(ProjectId);
        request.Name.Should().Be(Name);
    }
}
