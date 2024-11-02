// -----------------------------------------------------------------------
// <copyright file="ForwardEmailMessageRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.UnitTests.Emails.Requests;


[TestFixture]
internal sealed class ForwardEmailMessageRequestTests
{
    private const string Email = "john.doe@domain.com";


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenEmailIsNull()
    {
        var act = () => new ForwardEmailMessageRequest(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenEmailIsEmpty()
    {
        var act = () => new ForwardEmailMessageRequest(string.Empty);

        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ShouldInitializeFieldsCorrectly()
    {
        var request = new ForwardEmailMessageRequest(Email);

        request.Email.Should().Be(Email);
    }

    [Test]
    public void Validation_ShouldFail_WhenProvidedEmailIsInvalid()
    {
        var request = new ForwardEmailMessageRequest("abcdefg");

        var result = request.Validate();

        result.IsValid.Should().BeFalse();
    }

    [Test]
    public void Validation_ShouldNotFail_WhenProvidedEmailIsValid()
    {
        var request = new ForwardEmailMessageRequest(Email);

        var result = request.Validate();

        result.IsValid.Should().BeTrue();
    }
}
