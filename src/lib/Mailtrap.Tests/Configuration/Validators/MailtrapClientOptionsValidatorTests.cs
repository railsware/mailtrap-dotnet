// -----------------------------------------------------------------------
// <copyright file="MailtrapClientOptionsValidatorTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Configuration.Validators;


[TestFixture]
internal sealed class MailtrapClientOptionsValidatorTests
{
    [Test]
    public void Validation_ShouldFail_WhenAuthenticationIsNotInitialized()
    {
        var options = MailtrapClientOptions.Default;

        var result = MailtrapClientOptionsValidator.Instance.TestValidate(options);

        result.ShouldHaveValidationErrorFor(r => r.Authentication.ApiToken);
    }

    [Test]
    public void Validation_ShouldFail_WhenAuthenticationIsNull()
    {
        var options = MailtrapClientOptions.Default with
        {
            Authentication = null!
        };

        var result = MailtrapClientOptionsValidator.Instance.TestValidate(options);

        result.ShouldHaveValidationErrorFor(r => r.Authentication);
    }

    [Test]
    public void Validation_ShouldFail_WhenSendEndpointIsNull()
    {
        var options = MailtrapClientOptions.Default with
        {
            SendEndpoint = null!
        };

        var result = MailtrapClientOptionsValidator.Instance.TestValidate(options);

        result.ShouldHaveValidationErrorFor(r => r.SendEndpoint);
    }

    [Test]
    public void Validation_ShouldFail_WhenBulkEndpointIsNull()
    {
        var options = MailtrapClientOptions.Default with
        {
            BulkEndpoint = null!
        };

        var result = MailtrapClientOptionsValidator.Instance.TestValidate(options);

        result.ShouldHaveValidationErrorFor(r => r.BulkEndpoint);
    }

    [Test]
    public void Validation_ShouldFail_WhenTestEndpointIsNull()
    {
        var options = MailtrapClientOptions.Default with
        {
            TestEndpoint = null!
        };

        var result = MailtrapClientOptionsValidator.Instance.TestValidate(options);

        result.ShouldHaveValidationErrorFor(r => r.TestEndpoint);
    }

    [Test]
    public void Validation_ShouldFail_WhenSerializationIsNull()
    {
        var options = MailtrapClientOptions.Default with
        {
            Serialization = null!
        };

        var result = MailtrapClientOptionsValidator.Instance.TestValidate(options);

        result.ShouldHaveValidationErrorFor(r => r.Serialization);
    }
}
