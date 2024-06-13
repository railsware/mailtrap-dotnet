// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequestValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Email.Validators;


internal class ReguarSendEmailApiRequestValidator : AbstractValidator<RegularSendEmailApiRequest>
{
    public static ReguarSendEmailApiRequestValidator Instance { get; } = new();

    public ReguarSendEmailApiRequestValidator()
    {
        RuleFor(r => r).SetValidator(SendEmailApiRequestValidator.Instance);

        RuleFor(r => r.Subject).NotNull().MinimumLength(1);
        RuleFor(r => r.TextBody).NotNull().MinimumLength(1).When(r => string.IsNullOrEmpty(r.HtmlBody));
        RuleFor(r => r.HtmlBody).NotNull().MinimumLength(1).When(r => string.IsNullOrEmpty(r.TextBody));
    }
}
