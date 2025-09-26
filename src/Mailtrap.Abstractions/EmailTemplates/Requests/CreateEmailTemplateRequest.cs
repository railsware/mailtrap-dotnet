namespace Mailtrap.EmailTemplates.Requests;


/// <summary>
/// Request object for creating email template.
/// </summary>
public sealed record CreateEmailTemplateRequest : EmailTemplateRequest
{
    /// <inheritdoc />
    public CreateEmailTemplateRequest(string name, string category, string subject) : base(name, category, subject) { }
}
