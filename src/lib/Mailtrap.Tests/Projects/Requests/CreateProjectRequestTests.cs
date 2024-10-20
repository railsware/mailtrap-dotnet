// -----------------------------------------------------------------------
// <copyright file="CreateProjectRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Projects.Requests;


[TestFixture]
internal sealed class CreateProjectRequestTests
{
    private const string Name = "Test Project";


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsNull()
    {
        var act = () => new CreateProjectRequest(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsEmpty()
    {
        var act = () => new CreateProjectRequest(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        var request = new CreateProjectRequest(Name);

        request.Name.Should().Be(Name);
    }
}
