namespace Mailtrap.ContactImports;

/// <summary>
/// Implementation of Contact Imports Collection resource.
/// </summary>
internal sealed class ContactsImportCollectionResource : RestResource, IContactsImportCollectionResource
{
    public ContactsImportCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<ContactsImport> Create(ContactsImportRequest request, CancellationToken cancellationToken = default)
        => await Create<ContactsImportRequest, ContactsImport>(request, cancellationToken).ConfigureAwait(false);
}
