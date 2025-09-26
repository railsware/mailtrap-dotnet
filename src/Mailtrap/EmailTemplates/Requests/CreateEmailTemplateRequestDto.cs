namespace Mailtrap.EmailTemplates.Requests;


/// <summary>
/// Request object for creating email template.
/// </summary>
internal sealed record CreateEmailTemplateRequestDto : EmailTemplateRequestDto<EmailTemplateRequest>
{
    public CreateEmailTemplateRequestDto(EmailTemplateRequest emailTemplate) : base(emailTemplate) { }
}
