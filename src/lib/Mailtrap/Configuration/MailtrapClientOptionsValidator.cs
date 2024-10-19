// -----------------------------------------------------------------------
// <copyright file="MailtrapClientOptionsValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


internal class MailtrapClientOptionsValidator : AbstractValidator<MailtrapClientOptions>
{
    public static MailtrapClientOptionsValidator Instance { get; } = new();

    public MailtrapClientOptionsValidator()
    {
        RuleFor(o => o.ApiToken).NotEmpty();
    }
}
