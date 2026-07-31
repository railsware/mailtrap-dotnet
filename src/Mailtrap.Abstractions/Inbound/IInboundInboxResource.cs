namespace Mailtrap.Inbound;


/// <summary>
/// Represents an inbound inbox resource for management (folder-scoped).<br/>
/// To work with the inbox's messages and threads, use
/// <see cref="IInboundResource.Inbox(long)"/>.
/// </summary>
public interface IInboundInboxResource : IRestResource
{
    /// <summary>
    /// Gets details of the inbox, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Requested inbox details.
    /// </returns>
    public Task<InboundInbox> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the inbox, represented by the current resource instance, with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Inbox details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Updated inbox details.
    /// </returns>
    public Task<InboundInbox> Update(UpdateInboundInboxRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Permanently deletes the inbox, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// A task that represents the asynchronous delete operation.
    /// </returns>
    public Task Delete(CancellationToken cancellationToken = default);
}
