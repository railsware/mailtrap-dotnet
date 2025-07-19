namespace Mailtrap.Attachments;


internal sealed class AttachmentResource : RestResource, IAttachmentResource
{
    public AttachmentResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<EmailAttachment> GetDetails(CancellationToken cancellationToken = default)
        => await Get<EmailAttachment>(cancellationToken).ConfigureAwait(false);
}
