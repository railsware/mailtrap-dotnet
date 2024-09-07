// -----------------------------------------------------------------------
// <copyright file="MailtrapClientOptionsValidatorTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Configuration;


[TestFixture]
internal sealed class MailtrapClientOptionsValidatorTests
{
    [Test]
    public void Validation_ShouldFail_WhenAuthenticationIsNotInitialized()
    {
        var options = MailtrapClientOptions.Default;

        var result = MailtrapClientOptionsValidator.Instance.TestValidate(options);

        result.ShouldHaveValidationErrorFor(r => r.ApiToken);
    }
}
