namespace Mailtrap.EmailTemplates.Validators;


/// <summary>
/// Validator for <see cref="EmailTemplateRequest"/> requests.<br/>
/// Ensures email template's Name, Category, Subject are not empty and do not exceed 255 characters each.<br/>
/// Also ensures BodyText and BodyHtml do not exceed 10,000,000 characters each if provided.
/// </summary>
public sealed class EmailTemplateRequestValidator : AbstractValidator<EmailTemplateRequest>
{
    /// <summary>
    /// Static validator instance for reuse.
    /// </summary>
    public static EmailTemplateRequestValidator Instance { get; } = new();

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public EmailTemplateRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty().MaximumLength(255);
        RuleFor(r => r.Category).NotEmpty().MaximumLength(255);
        RuleFor(r => r.Subject).NotEmpty().MaximumLength(255);
        RuleFor(r => r.BodyText).MaximumLength(10_000_000);
        RuleFor(r => r.BodyHtml).MaximumLength(10_000_000);
    }
}
