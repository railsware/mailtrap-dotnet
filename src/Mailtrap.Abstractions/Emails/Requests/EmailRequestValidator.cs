namespace Mailtrap.Emails.Requests;


internal sealed class EmailRequestValidator : AbstractValidator<EmailRequest>
{
    public static EmailRequestValidator Instance { get; } = new();

    public EmailRequestValidator()
    {
        RuleFor(r => r.From!)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .SetValidator(EmailAddressValidator.Instance);

        RuleFor(r => r.ReplyTo!)
            .SetValidator(EmailAddressValidator.Instance)
            .When(r => r.ReplyTo is not null);

        RuleFor(r => r.Attachments)
            .NotNull();
        RuleForEach(r => r.Attachments)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .SetValidator(AttachmentValidator.Instance);

        When(r => string.IsNullOrEmpty(r.TemplateId), () =>
        {
            RuleFor(r => r.Subject)
                .NotNull()
                .MinimumLength(1);

            RuleFor(r => r.Category)
                .MaximumLength(255);

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
