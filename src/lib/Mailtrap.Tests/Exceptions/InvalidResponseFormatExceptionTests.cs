// -----------------------------------------------------------------------
// <copyright file="InvalidResponseFormatExceptionTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Exceptions;


[TestFixture]
internal sealed class InvalidResponseFormatExceptionTests
{
    [Test]
    public void Constructor_WithoutParams_ShouldProperlyInitializeProperties()
    {
        var ex = new InvalidResponseFormatException();

        ex.Message.Should().Be("Response received from the 'Mailtrap' API call has an invalid format.");
    }

    [Test]
    public void Constructor_WithMessageParam_ShouldProperlyInitializeProperties()
    {
        var message = "Test message";
        var ex = new InvalidResponseFormatException(message);

        ex.Message.Should().Be(message);
    }

    [Test]
    public void Constructor_WithMessageAndInnerException_ShouldProperlyInitializeProperties()
    {
        var message = "Test message";
        var innerEx = new ArgumentException();
        var ex = new InvalidResponseFormatException(message, innerEx);

        ex.Message.Should().Be(message);
        ex.InnerException.Should().BeSameAs(innerEx);
    }

    [Test]
    public void Create_ShouldThrowArgumentNullException_WhenApiEndpointIsNull()
    {
        var act = () => InvalidResponseFormatException.Create(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Create_ShouldThrowArgumentNullException_WhenApiEndpointIsEmpty()
    {
        var act = () => InvalidResponseFormatException.Create(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Create_ShouldInitializeMessageProperly_WhenApiEndpointIsValid()
    {
        var api = "Test API";

        var ex = InvalidResponseFormatException.Create(api);

        ex.Message.Should().Be($"Response received from the '{api}' API call has an invalid format.");
    }
}
