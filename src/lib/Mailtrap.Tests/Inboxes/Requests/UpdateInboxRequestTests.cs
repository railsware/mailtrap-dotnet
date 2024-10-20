// -----------------------------------------------------------------------
// <copyright file="UpdateInboxRequestTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Inboxes.Requests;


[TestFixture]
internal sealed class UpdateInboxRequestTests
{
    [Test]
    public void Validation_ShouldFail_WhenAllFieldsAreNull()
    {
        var request = new UpdateInboxRequest();

        var result = request.Validate();

        result.IsValid.Should().BeFalse();
    }

    [Test]
    public void Validation_ShouldFail_WhenAllFieldsAreEmpty()
    {
        var request = new UpdateInboxRequest()
        {
            Name = string.Empty,
            EmailUsername = string.Empty
        };

        var result = request.Validate();

        result.IsValid.Should().BeFalse();
    }

    [Test]
    public void Validation_ShouldFail_WhenNameIsEmpty()
    {
        var request = new UpdateInboxRequest()
        {
            Name = string.Empty,
            EmailUsername = "Test User"
        };

        var result = request.Validate();

        result.IsValid.Should().BeFalse();
    }

    [Test]
    public void Validation_ShouldFail_WhenEmailUsernameIsEmpty()
    {
        var request = new UpdateInboxRequest()
        {
            Name = "Test Inbox",
            EmailUsername = string.Empty
        };

        var result = request.Validate();

        result.IsValid.Should().BeFalse();
    }

    [Test]
    public void Validation_ShouldNotFail_WhenNameIsNull()
    {
        var request = new UpdateInboxRequest()
        {
            EmailUsername = "Test User"
        };

        var result = request.Validate();

        result.IsValid.Should().BeTrue();
    }

    [Test]
    public void Validation_ShouldNotFail_WhenEmailUsernameIsNull()
    {
        var request = new UpdateInboxRequest()
        {
            Name = "Test Inbox"
        };

        var result = request.Validate();

        result.IsValid.Should().BeTrue();
    }

    [Test]
    public void Validation_ShouldNotFail_WhenRequestIsValid()
    {
        var request = new UpdateInboxRequest()
        {
            Name = "Test Inbox",
            EmailUsername = "Test User"
        };

        var result = request.Validate();

        result.IsValid.Should().BeTrue();
    }
}
