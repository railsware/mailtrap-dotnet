namespace Mailtrap.ContactLists;

/// <summary>
/// Represents Contacts Lists collection resource.
/// </summary>
public interface IContactsListCollectionResource : IRestResource
{
    /// <summary>
    /// Gets all contacts lists.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Collection of contacts lists details.
    /// </returns>
    public Task<IList<ContactsList>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new contacts list with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing contacts list details for creation.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Created contacts list details.
    /// </returns>
    public Task<ContactsList> Create(ContactsListRequest request, CancellationToken cancellationToken = default);
}
