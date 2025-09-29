namespace Mailtrap.EmailTemplates.Requests;

internal static class EmailTemplateRequestExtensions
{
    public static CreateEmailTemplateRequestDto ToDto(this CreateEmailTemplateRequest request) => new(request);

    public static UpdateEmailTemplateRequestDto ToDto(this UpdateEmailTemplateRequest request) => new(request);
}
