namespace Mailtrap.ContactImports;

/// <summary>
/// Represents contact import collection resource.
/// </summary>
public interface IContactImportCollectionResource : IRestResource
{
    /// <summary>
    /// Import contacts in bulk with support for custom fields and list management.
    /// Existing contacts with matching email addresses will be updated automatically.
    /// You can import up to 50,000 contacts per request.
    /// The import process runs asynchronously - use the returned
    /// import ID to check the status and results.
    /// Provide the contacts to import in the <paramref name="request"/>.
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
    /// <see cref="ContactImport"/> containing the import Id and status.
    /// </returns>
    public Task<ContactImport> Create(CreateContactImportRequest request, CancellationToken cancellationToken = default);
}
