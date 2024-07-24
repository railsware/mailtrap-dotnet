// -----------------------------------------------------------------------
// <copyright file="MailtrapClientOptionsValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Validators;


internal class MailtrapClientOptionsValidator : AbstractValidator<MailtrapClientOptions>
{
    public static MailtrapClientOptionsValidator Instance { get; } = new();

    public MailtrapClientOptionsValidator()
    {
        RuleFor(o => o.Authentication)
            .NotNull()
            .SetValidator(MailtrapClientAuthenticationOptionsValidator.Instance);

        RuleFor(o => o.TestEndpoint).NotNull();

        RuleFor(o => o.SendEndpoint).NotNull();

        RuleFor(o => o.BulkEndpoint).NotNull();

        RuleFor(o => o.Serialization).NotNull();
    }
}
