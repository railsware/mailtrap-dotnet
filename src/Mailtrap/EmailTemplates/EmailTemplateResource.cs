namespace Mailtrap.EmailTemplates;

/// <summary>
/// Implementation of Email Templates API operations.
/// </summary>
internal sealed class EmailTemplateResource : RestResource, IEmailTemplateResource
{
    public EmailTemplateResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }
    public async Task<EmailTemplate> GetDetails(CancellationToken cancellationToken = default)
        => await Get<EmailTemplate>(cancellationToken).ConfigureAwait(false);
    public async Task<EmailTemplate> Update(UpdateEmailTemplateRequest request, CancellationToken cancellationToken = default)
        => await Update<UpdateEmailTemplateRequestDto, EmailTemplate>(request.ToDto(), cancellationToken).ConfigureAwait(false);
    public async Task Delete(CancellationToken cancellationToken = default)
        => await DeleteWithStatusCodeResult(cancellationToken).ConfigureAwait(false);
}
