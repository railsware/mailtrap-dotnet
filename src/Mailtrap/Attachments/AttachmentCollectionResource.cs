// -----------------------------------------------------------------------
// <copyright file="AttachmentCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Attachments;


internal sealed class AttachmentCollectionResource : RestResource, IAttachmentCollectionResource
{
    private const string AttachmentTypeQueryParameter = "attachment_type";


    public AttachmentCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<IList<EmailAttachment>> Fetch(
        EmailAttachmentFilter? filter = null,
        CancellationToken cancellationToken = default)
        => await GetList<EmailAttachment>(CreateFetchUri(filter), cancellationToken).ConfigureAwait(false);


    private Uri CreateFetchUri(EmailAttachmentFilter? filter)
    {
        var uri = ResourceUri;

        if (filter?.Disposition is not null)
        {
            var disposition = filter.Disposition.ToString();
            uri = uri.AppendQueryParameter(AttachmentTypeQueryParameter, disposition);
        }

        return uri;
    }
}
