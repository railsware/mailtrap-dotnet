namespace Mailtrap.ContactLists;

/// <summary>
/// Represents the contact list collection resource.
/// </summary>
public interface IContactListCollectionResource : IRestResource
{
    /// <summary>
    /// Gets collection of contact list details.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// A collection of contact list details.
    /// </returns>
    public Task<IList<ContactList>> GetAll(CancellationToken cancellationToken = default);

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
    /// Created contact list details.
    /// </returns>
    public Task<ContactList> Create(ContactListRequest request, CancellationToken cancellationToken = default);
}
