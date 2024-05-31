// -----------------------------------------------------------------------
// <copyright file="RecipientValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Validators;


internal class RecipientValidator : AbstractValidator<Recipient>
{
    public static readonly RecipientValidator Instance = new();

    public RecipientValidator()
    {
        var Boak = new List<Recipient>();

        RuleFor(r => r.EmailAddress).NotNull().EmailAddress();
    }
}
