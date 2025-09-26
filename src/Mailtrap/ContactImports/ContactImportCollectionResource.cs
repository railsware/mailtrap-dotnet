namespace Mailtrap.ContactImports;

/// <summary>
/// Implementation of Contact Import Collection resource.
/// </summary>
internal sealed class ContactImportCollectionResource : RestResource, IContactImportCollectionResource
{
    public ContactImportCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<ContactImport> Create(CreateContactImportRequest request, CancellationToken cancellationToken = default)
        => await Create<CreateContactImportRequest, ContactImport>(request, cancellationToken).ConfigureAwait(false);
}
