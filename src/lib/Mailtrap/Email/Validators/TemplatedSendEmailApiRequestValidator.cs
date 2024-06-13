// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequestValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Email.Validators;


internal class TemplatedSendEmailApiRequestValidator : AbstractValidator<TemplatedSendEmailApiRequest>
{
    public static TemplatedSendEmailApiRequestValidator Instance { get; } = new();

    public TemplatedSendEmailApiRequestValidator()
    {
        RuleFor(r => r).SetValidator(SendEmailApiRequestValidator.Instance);

        RuleFor(r => r.TemplateId).NotNull().MinimumLength(1);
    }
}
