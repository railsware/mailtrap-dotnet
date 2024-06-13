// -----------------------------------------------------------------------
// <copyright file="RecipientValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Email.Validators;


internal class EmailPartyValidator : AbstractValidator<EmailParty>
{
    public static EmailPartyValidator Instance { get; } = new();

    public EmailPartyValidator()
    {
        RuleFor(r => r.EmailAddress).NotNull().EmailAddress();
    }
}
