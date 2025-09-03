namespace Mailtrap.Contacts;

/// <summary>
/// Represents Contacts collection resource..
/// </summary>
public interface IContactCollectionResource : IRestResource
{
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
