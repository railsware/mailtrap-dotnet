// -----------------------------------------------------------------------
// <copyright file="EmailAddressValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Validators;


internal sealed class EmailAddressValidator : AbstractValidator<EmailAddress>
{
    public static EmailAddressValidator Instance { get; } = new();

    public EmailAddressValidator()
    {
        RuleFor(r => r.Email).NotNull().EmailAddress();
    }
}
