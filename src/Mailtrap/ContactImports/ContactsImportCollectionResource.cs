using Mailtrap.ContactImports.Responses;

namespace Mailtrap.ContactImports;

/// <summary>
/// Implementation of Contact Imports Collection resource.
/// </summary>
internal sealed class ContactsImportCollectionResource : RestResource, IContactsImportCollectionResource
{
    public ContactsImportCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<ContactsImportResponse> Create(ContactsImportRequest request, CancellationToken cancellationToken = default)
        => await Create<ContactsImportRequest, ContactsImportResponse>(request, cancellationToken).ConfigureAwait(false);
}
