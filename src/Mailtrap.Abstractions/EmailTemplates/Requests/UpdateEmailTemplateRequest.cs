namespace Mailtrap.EmailTemplates.Requests;


/// <summary>
/// Request object for updating email template.
/// </summary>
public sealed record UpdateEmailTemplateRequest : EmailTemplateRequest
{
    /// <inheritdoc />
    public UpdateEmailTemplateRequest(string name, string category, string subject) : base(name, category, subject) { }
}
