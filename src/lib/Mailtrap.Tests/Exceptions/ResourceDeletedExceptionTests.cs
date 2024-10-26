// -----------------------------------------------------------------------
// <copyright file="ResourceDeletedExceptionTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Exceptions;


[TestFixture]
internal sealed class ResourceDeletedExceptionTests
{
    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenApiEndpointIsNull()
    {
        var act = () => new ResourceDeletedException(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializePropertiesCorrectly()
    {
        var resource = new Uri("TestAPI", UriKind.Relative);

        var ex = new ResourceDeletedException(resource);

        ex.Message.Should().Be("Resource was deleted and can't be used anymore.");
        ex.ResourceUri.Should().Be(resource);
    }
}
