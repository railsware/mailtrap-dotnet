// -----------------------------------------------------------------------
// <copyright file="EmailAddressValidatorTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.UnitTests.Emails.Validators;


[TestFixture]
internal sealed class EmailAddressValidatorTests
{
    [Test]
    public void Validation_ShouldFail_WhenProvidedEmailIsInvalid()
    {
        var recipient = new EmailAddress("abcdefg");

        var result = EmailAddressValidator.Instance.TestValidate(recipient);

        result.ShouldHaveValidationErrorFor(r => r.Email);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenProvidedEmailIsValid()
    {
        var recipient = new EmailAddress("john.doe@domain.com");

        var result = EmailAddressValidator.Instance.TestValidate(recipient);

        result.ShouldNotHaveValidationErrorFor(r => r.Email);
    }

    [Test]
    public void Validation_ShouldNotFail_WhenDisplayNameisEmpty()
    {
        var recipient = new EmailAddress("john.doe@domain.com");

        var result = EmailAddressValidator.Instance.TestValidate(recipient);

        result.ShouldNotHaveValidationErrorFor(r => r.DisplayName);
    }
}
