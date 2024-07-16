// -----------------------------------------------------------------------
// <copyright file="MailtrapClientAuthenticationOptionsValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Validators;


internal class MailtrapClientAuthenticationOptionsValidator : AbstractValidator<MailtrapClientAuthenticationOptions>
{
    public static MailtrapClientAuthenticationOptionsValidator Instance { get; } = new();

    public MailtrapClientAuthenticationOptionsValidator()
    {
        RuleFor(o => o.ApiToken).NotEmpty();
    }
}
