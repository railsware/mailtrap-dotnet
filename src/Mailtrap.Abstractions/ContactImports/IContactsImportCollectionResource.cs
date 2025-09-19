namespace Mailtrap.ContactImports;

/// <summary>
/// Represents Contact imports collection resource.
/// </summary>
public interface IContactsImportCollectionResource : IRestResource
{
    /// <summary>
    /// Import contacts in bulk with support for custom fields and list management.
    /// Existing contacts with matching email addresses will be updated automatically.
    /// You can import up to 50,000 contacts per request.
    /// The import process runs asynchronously - use the returned
    /// import ID to check the status and results.
    /// List all contacts with details into <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing contact list for import.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Contact import id and status.
    /// </returns>
    public Task<ContactsImport> Create(ContactsImportRequest request, CancellationToken cancellationToken = default);
}
