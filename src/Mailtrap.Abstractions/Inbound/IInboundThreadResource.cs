namespace Mailtrap.Inbound;


/// <summary>
/// Represents an inbound thread resource.
/// </summary>
public interface IInboundThreadResource : IRestResource
{
    /// <summary>
    /// Gets the thread (with its messages embedded, oldest first), represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Requested thread details.
    /// </returns>
    public Task<InboundThread> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Permanently deletes the thread, represented by the current resource instance.<br/>
    /// Inbound messages in the thread are removed; sent messages are preserved.
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
