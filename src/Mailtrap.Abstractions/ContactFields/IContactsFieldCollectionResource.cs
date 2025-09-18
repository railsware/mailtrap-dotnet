namespace Mailtrap.ContactFields;

/// <summary>
/// Represents contacts field collection resource.
/// </summary>
public interface IContactsFieldCollectionResource : IRestResource
{
    /// <summary>
    /// Gets list of contact fields.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Collection of contact fields.
    /// </returns>
    public Task<IList<ContactsField>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new contacts field with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing contacts field details for creation.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Created contacts field details.
    /// </returns>
    public Task<ContactsField> Create(CreateContactsFieldRequest request, CancellationToken cancellationToken = default);
}
