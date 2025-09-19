namespace Mailtrap.ContactLists;

/// <summary>
/// Represents the contact lists collection resource.
/// </summary>
public interface IContactsListCollectionResource : IRestResource
{
    /// <summary>
    /// Retrieves all contact lists.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// A collection of contact list details.
    /// </returns>
    public Task<IList<ContactsList>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new contact list with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// The request containing contact list details for creation.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// The created contact list.
    /// </returns>
    public Task<ContactsList> Create(ContactsListRequest request, CancellationToken cancellationToken = default);
}
