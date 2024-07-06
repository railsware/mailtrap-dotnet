// -----------------------------------------------------------------------
// <copyright file="MailtrapClientAuthenticationOptionsValidatorTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Tests.Configuration.Validators;


[TestFixture]
internal sealed class MailtrapClientAuthenticationOptionsValidatorTests
{
    [Test]
    public void Validation_ShouldFail_WhenProvidedTokenIsEmpty()
    {
        var result = MailtrapClientAuthenticationOptionsValidator.Instance.TestValidate(MailtrapClientAuthenticationOptions.Empty);

        result.ShouldHaveValidationErrorFor(r => r.ApiToken);
    }
}
