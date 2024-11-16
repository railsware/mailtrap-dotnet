// -----------------------------------------------------------------------
// <copyright file="ProjectRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Projects.Requests;


[TestFixture]
internal sealed class ProjectRequestTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsNull()
    {
        var act = () => new ProjectRequest(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenNameIsEmpty()
    {
        var act = () => new ProjectRequest(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        var name = TestContext.CurrentContext.Random.GetString(25);

        var request = new ProjectRequest(name);

        request.Name.Should().Be(name);
    }

    [Test]
    public void Validate_ShouldFail_WhenProvidedNameLengthIsInvalid([Values(1, 101)] int length)
    {
        // Arrange
        var name = TestContext.CurrentContext.Random.GetString(length);
        var request = new ProjectRequest(name);

        // Act
        var result = request.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }
}
