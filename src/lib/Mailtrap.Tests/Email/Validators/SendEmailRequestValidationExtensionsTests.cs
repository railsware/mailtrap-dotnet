// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestValidationExtensionsTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Email.Validators;


[TestFixture]
internal sealed class SendEmailRequestValidationExtensionsTests
{
    [Test]
    public void IsValid_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        SendEmailRequest? request = null;

        var act = () => request!.IsValid();

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void IsValid_ShouldReturnFalse_WhenRequestIsInvalid()
    {
        var request = SendEmailRequestBuilder.Email();

        request.IsValid().Should().BeFalse();
    }

    [Test]
    public void IsValid_ShouldReturnTrue_WhenRequestIsValid()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .From("sender@domain.com")
            .To("recipient@domain.com")
            .Subject("Subject")
            .Text("Content");

        request.IsValid().Should().BeTrue();
    }

    [Test]
    public void Validate_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        SendEmailRequest? request = null;

        var act = () => request!.Validate();

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void IsValid_ShouldThrowValidationException_WhenRequestIsInvalid()
    {
        var request = SendEmailRequestBuilder.Email();

        var act = () => request!.Validate();

        act.Should().Throw<ValidationException>();
    }

    [Test]
    public void IsValid_ShouldNotThrowException_WhenRequestIsValid()
    {
        var request = SendEmailRequestBuilder
            .Email()
            .From("sender@domain.com")
            .To("recipient@domain.com")
            .Subject("Subject")
            .Text("Content");

        var act = () => request!.Validate();

        act.Should().NotThrow();
    }
}
