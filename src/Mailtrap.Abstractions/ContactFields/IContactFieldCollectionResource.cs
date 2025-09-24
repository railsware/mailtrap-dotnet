namespace Mailtrap.ContactFields;

/// <summary>
/// Represents contact field collection resource.
/// </summary>
public interface IContactFieldCollectionResource : IRestResource
{
    /// <summary>
    /// Gets collection of contact field details.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Collection of contact field details.
    /// </returns>
    public Task<IList<ContactField>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new contact field with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing contact field details for creation.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Created contact field details.
    /// </returns>
    public Task<ContactField> Create(CreateContactFieldRequest request, CancellationToken cancellationToken = default);
}
