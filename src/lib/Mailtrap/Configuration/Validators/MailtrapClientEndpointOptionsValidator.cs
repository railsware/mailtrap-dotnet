// -----------------------------------------------------------------------
// <copyright file="MailtrapClientEndpointOptionsValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Validators;


internal class MailtrapClientEndpointOptionsValidator : AbstractValidator<MailtrapClientEndpointOptions>
{
    public static MailtrapClientEndpointOptionsValidator Instance { get; } = new();

    public MailtrapClientEndpointOptionsValidator()
    {
        RuleFor(o => o.BaseUrl)
            .NotEmpty()
            .Must(o => o.IsAbsoluteUri);
    }
}
