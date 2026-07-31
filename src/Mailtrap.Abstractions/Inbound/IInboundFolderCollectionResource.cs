namespace Mailtrap.Inbound;


/// <summary>
/// Represents the inbound folder collection resource.
/// </summary>
public interface IInboundFolderCollectionResource : IRestResource
{
    /// <summary>
    /// Returns all inbound folders.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Collection of inbound folders.
    /// </returns>
    public Task<IList<InboundFolder>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new inbound folder with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing folder details for creation.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Created folder details.
    /// </returns>
    public Task<InboundFolder> Create(CreateInboundFolderRequest request, CancellationToken cancellationToken = default);
}
