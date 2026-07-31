namespace Mailtrap.Inbound;


/// <summary>
/// Represents an inbound folder resource.
/// </summary>
public interface IInboundFolderResource : IRestResource
{
    /// <summary>
    /// Gets details of the folder, represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Requested folder details.
    /// </returns>
    public Task<InboundFolder> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the folder, represented by the current resource instance, with details specified by <paramref name="request"/>.
    /// </summary>
    ///
    /// <param name="request">
    /// Folder details for update.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Updated folder details.
    /// </returns>
    public Task<InboundFolder> Update(UpdateInboundFolderRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Permanently deletes the folder (and all of its inboxes), represented by the current resource instance.
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

    /// <summary>
    /// Gets the inbox collection resource for this folder.
    /// </summary>
    ///
    /// <returns>
    /// Inbox collection resource for this folder.
    /// </returns>
    public IInboundInboxCollectionResource Inboxes();

    /// <summary>
    /// Gets the resource for a specific inbox in this folder, identified by <paramref name="inboxId"/>.
    /// </summary>
    ///
    /// <param name="inboxId">
    /// ID of the inbox to get resource for.
    /// </param>
    ///
    /// <returns>
    /// Resource for the inbox with the specified ID.
    /// </returns>
    public IInboundInboxResource Inbox(long inboxId);
}
