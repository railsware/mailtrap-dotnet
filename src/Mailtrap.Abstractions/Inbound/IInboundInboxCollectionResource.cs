namespace Mailtrap.Inbound;


/// <summary>
/// Represents the inbound inbox collection resource for a folder.
/// </summary>
public interface IInboundInboxCollectionResource : IRestResource
{
    /// <summary>
    /// Returns all inboxes in the folder.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Collection of inboxes in the folder.
    /// </returns>
    public Task<IList<InboundInbox>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new inbox in the folder with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing inbox details for creation.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Created inbox details.
    /// </returns>
    public Task<InboundInbox> Create(CreateInboundInboxRequest request, CancellationToken cancellationToken = default);
}
