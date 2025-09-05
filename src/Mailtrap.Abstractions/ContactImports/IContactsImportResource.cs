namespace Mailtrap.ContactImports;

/// <summary>
/// Represents Contact import resource.
/// </summary>
public interface IContactsImportResource : IRestResource
{
    /// <summary>
    /// Gets details of the contact import, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Requested contact import details.
    /// </returns>
    public Task<ContactsImport> GetDetails(CancellationToken cancellationToken = default);
}
