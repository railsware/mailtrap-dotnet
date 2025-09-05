namespace Mailtrap.Contacts;

/// <summary>
/// Represents Contacts collection resource..
/// </summary>
public interface IContactCollectionResource : IRestResource
{
    /// <summary>
    /// Gets contact imports collection resource for the account, represented by this resource instance.
    /// </summary>
    ///
    /// <returns>
    /// Contact imports collection resource for the account, represented by this resource instance.
    /// </returns>
    public IContactsImportCollectionResource Imports();

    /// <summary>
    /// Gets resource for specific contacts import, identified by <paramref name="importId"/>.
    /// </summary>
    ///
    /// <param name="importId">
    /// Unique Contact Import ID to get resource for.
    /// </param>
    ///
    /// <returns>
    /// Resource for the contact with specified ID or email.
    /// </returns>
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="importId"/> is less than or equal to zero.
    /// </exception>
    public IContactsImportResource Import(long importId);

    /// <summary>
    /// Gets contacts.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Collection of contact details.
    /// </returns>
    public Task<IList<Contact>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new contact with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing contact details for creation.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Created contact details.
    /// </returns>
    public Task<CreateContactResponse> Create(CreateContactRequest request, CancellationToken cancellationToken = default);
}
