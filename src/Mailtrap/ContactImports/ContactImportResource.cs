namespace Mailtrap.ContactImports;

/// <summary>
/// Implementation of Contact Import API operations.
/// </summary>
internal sealed class ContactImportResource : RestResource, IContactImportResource
{
    public ContactImportResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }

    public async Task<ContactImport> GetDetails(CancellationToken cancellationToken = default)
        => await Get<ContactImport>(cancellationToken).ConfigureAwait(false);
}
