// -----------------------------------------------------------------------
// <copyright file="RecipientValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Validators;


internal class RecipientValidator : AbstractValidator<EmailParty>
{
    public static readonly RecipientValidator Instance = new();

    public RecipientValidator()
    {
        var Boak = new List<EmailParty>();

        RuleFor(r => r.EmailAddress).NotNull().EmailAddress();
    }
}
