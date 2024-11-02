// -----------------------------------------------------------------------
// <copyright file="ForwardEmailMessageRequestValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Validators;


internal sealed class ForwardEmailMessageRequestValidator : AbstractValidator<ForwardEmailMessageRequest>
{
    public static ForwardEmailMessageRequestValidator Instance { get; } = new();

    public ForwardEmailMessageRequestValidator()
    {
        RuleFor(r => r.Email).NotNull().EmailAddress();
    }
}
