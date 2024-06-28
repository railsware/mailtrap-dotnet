// -----------------------------------------------------------------------
// <copyright file="MailtrapClientEndpointOptionsValidatorTests.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Mailtrap.Configuration.Validators;

namespace Mailtrap.Tests.Configuration.Validators;


[TestFixture]
internal sealed class MailtrapClientEndpointOptionsValidatorTests
{
    [Test]
    public void Validation_ShouldFail_WhenBaseUrlIsRelativeUrl()
    {
        var uri = new Uri("api/send", UriKind.Relative);

        var options = new MailtrapClientEndpointOptions(uri);

        var result = MailtrapClientEndpointOptionsValidator.Instance.TestValidate(options);

        result.ShouldHaveValidationErrorFor(r => r.BaseUrl);
    }
}
