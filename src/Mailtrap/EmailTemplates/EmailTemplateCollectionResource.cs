namespace Mailtrap.EmailTemplates;

/// <summary>
/// Implementation of Email Template Collection resource.
/// </summary>
internal sealed class EmailTemplateCollectionResource : RestResource, IEmailTemplateCollectionResource
{
    public EmailTemplateCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<IList<EmailTemplate>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<EmailTemplate>(cancellationToken).ConfigureAwait(false);

    public async Task<EmailTemplate> Create(CreateEmailTemplateRequest request, CancellationToken cancellationToken = default)
        => await Create<CreateEmailTemplateRequestDto, EmailTemplate>(request.ToDto(), cancellationToken).ConfigureAwait(false);
}
