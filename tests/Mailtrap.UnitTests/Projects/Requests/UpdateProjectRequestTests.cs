// -----------------------------------------------------------------------
// <copyright file="UpdateProjectRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.Projects.Requests;


[TestFixture]
internal sealed class UpdateProjectRequestTests
{
    private const string Name = "Test Project";


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsNull()
    {
        var act = () => new UpdateProjectRequest(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsEmpty()
    {
        var act = () => new UpdateProjectRequest(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        var request = new UpdateProjectRequest(Name);

        request.Name.Should().Be(Name);
    }
}
