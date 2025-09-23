namespace Mailtrap.ContactImports;

/// <summary>
/// Implementation of Contact Imports API operations.
/// </summary>
internal sealed class ContactsImportResource : RestResource, IContactsImportResource
{
    public ContactsImportResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<ContactsImport> GetDetails(CancellationToken cancellationToken = default)
        => await Get<ContactsImport>(cancellationToken).ConfigureAwait(false);
}
