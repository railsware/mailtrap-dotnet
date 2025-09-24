namespace Mailtrap.Contacts;

/// <summary>
/// Represents Contacts collection resource.
/// Represents Contacts collection resource.
/// </summary>
public interface IContactCollectionResource : IRestResource
{
    /// <summary>
    /// Gets contacts import collection resource for the account, represented by this resource instance.
    /// </summary>
    ///
    /// <returns>
    /// <see cref="IContactsImportCollectionResource"/> for the account, represented by this resource instance.
    /// </returns>
    public IContactsImportCollectionResource Imports();

    /// <summary>
    /// Gets resource for a specific contacts import identified by <paramref name="importId"/>.
    /// </summary>
    ///
    /// <param name="importId">
    /// Unique Contact Import ID to get resource for.
    /// </param>
    ///
    /// <returns>
    /// <see cref="IContactsImportResource"/> for the contacts import with the specified ID.
    /// </returns>
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="importId"/> is less than or equal to zero.
    /// </exception>
    public IContactsImportResource Import(long importId);

    /// <summary>
    /// Gets contacts lists collection resource for the account, represented by this resource instance.
    /// </summary>
    ///
    /// <returns>
    /// <see cref="IContactsListCollectionResource"/> for the account, represented by this resource instance.
    /// </returns>
    public IContactsListCollectionResource Lists();

    /// <summary>
    /// Gets resource for a specific contacts list identified by <paramref name="listId"/>.
    /// </summary>
    ///
    /// <param name="listId">
    /// Unique Contacts List ID to get resource for.
    /// </param>
    ///
    /// <returns>
    /// <see cref="IContactsListResource"/> for the contacts list with the specified ID.
    /// </returns>
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="listId"/> is less than or equal to zero.
    /// </exception>
    public IContactsListResource List(long listId);

    /// <summary>
    /// Gets contacts fields collection resource for the account, represented by this resource instance.
    /// </summary>
    ///
    /// <returns>
    /// <see cref="IContactsFieldCollectionResource"/> for the account, represented by this resource instance.
    /// </returns>
    public IContactsFieldCollectionResource Fields();

    /// <summary>
    /// Gets resource for a specific contacts field identified by <paramref name="fieldId"/>.
    /// </summary>
    ///
    /// <param name="fieldId">
    /// Unique Contacts Field ID to get resource for.
    /// </param>
    ///
    /// <returns>
    /// <see cref="IContactsFieldResource"/> for the contacts field with the specified ID.
    /// </returns>
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="fieldId"/> is less than or equal to zero.
    /// </exception>
    public IContactsFieldResource Field(long fieldId);

    /// <summary>
    /// Gets contacts events collection resource for the account, represented by this resource instance.
    /// </summary>
    ///
    /// <param name="contactId">
    /// Unique Contact ID to get resource for.
    /// </param>
    ///
    /// <returns>
    /// <see cref="IContactsEventCollectionResource"/> for the account, represented by this resource instance.
    /// </returns>
    public IContactsEventCollectionResource Events(string contactId);

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
