namespace Mailtrap.ContactImports;

/// <summary>
/// Represents contact import resource.
/// </summary>
public interface IContactImportResource : IRestResource
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
    public Task<ContactImport> GetDetails(CancellationToken cancellationToken = default);
}
