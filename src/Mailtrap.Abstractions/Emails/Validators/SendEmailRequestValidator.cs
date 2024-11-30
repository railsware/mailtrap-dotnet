// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestValidator.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Emails.Validators;


internal sealed class SendEmailRequestValidator : AbstractValidator<SendEmailRequest>
{
    public static SendEmailRequestValidator Instance { get; } = new();

    public SendEmailRequestValidator()
    {
        RuleFor(r => r.From!).NotNull().SetValidator(EmailAddressValidator.Instance);

        RuleFor(r => r.To).Must(r => r.Count is <= 1000);
        RuleForEach(r => r.To).SetValidator(EmailAddressValidator.Instance);

        RuleFor(r => r.Cc).Must(r => r.Count is <= 1000);
        RuleForEach(r => r.Cc).SetValidator(EmailAddressValidator.Instance);

        RuleFor(r => r.Bcc).Must(r => r.Count is <= 1000);
        RuleForEach(r => r.Bcc).SetValidator(EmailAddressValidator.Instance);

        RuleFor(r => r)
            .Must(r => r.To.Count + r.Cc.Count + r.Bcc.Count > 0)
            .WithName("Recipients")
            .WithMessage("There should be at least one email recipient added to either To, Cc or Bcc.");

        RuleForEach(r => r.Attachments).SetValidator(AttachmentValidator.Instance);

        When(r => string.IsNullOrEmpty(r.TemplateId), () =>
        {
            RuleFor(r => r.Subject).NotNull().MinimumLength(1);

            RuleFor(r => r.Category).MaximumLength(255);

            RuleFor(r => r.TextBody)
                .NotNull()
                .MinimumLength(1)
                .When(r => string.IsNullOrEmpty(r.HtmlBody))
                .WithMessage($"Either '{nameof(SendEmailRequest.TextBody)}' or '{nameof(SendEmailRequest.HtmlBody)}' or both should be set to non-empty string, when template is not specified.");

            RuleFor(r => r.HtmlBody)
                .NotNull()
                .MinimumLength(1)
                .When(r => string.IsNullOrEmpty(r.TextBody))
                .WithMessage($"Either '{nameof(SendEmailRequest.TextBody)}' or '{nameof(SendEmailRequest.HtmlBody)}' or both should be set to non-empty string, when template is not specified.");
        });

        When(r => !string.IsNullOrEmpty(r.TemplateId), () =>
        {
            RuleFor(r => r.Subject)
                .Null()
                .WithMessage($"'{nameof(SendEmailRequest.Subject)}' should be null, when '{nameof(SendEmailRequest.TemplateId)}' is specified.");

            RuleFor(r => r.TextBody)
                .Null()
                .WithMessage($"'{nameof(SendEmailRequest.TextBody)}' should be null, when '{nameof(SendEmailRequest.TemplateId)}' is specified.");

            RuleFor(r => r.HtmlBody)
                .Null()
                .WithMessage($"'{nameof(SendEmailRequest.HtmlBody)}' should be null, when '{nameof(SendEmailRequest.TemplateId)}' is specified.");

            RuleFor(r => r.Category)
                .Null()
                .WithMessage($"'{nameof(SendEmailRequest.Category)}' should be null, when '{nameof(SendEmailRequest.TemplateId)}' is specified.");
        });
    }
}
