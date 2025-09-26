namespace Mailtrap.EmailTemplates.Requests;


/// <summary>
/// Request object for updating email template.
/// </summary>
internal sealed record UpdateEmailTemplateRequestDto : EmailTemplateRequestDto<EmailTemplateRequest>
{
    public UpdateEmailTemplateRequestDto(EmailTemplateRequest emailTemplate) : base(emailTemplate) { }
}
