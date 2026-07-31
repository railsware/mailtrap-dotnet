namespace Mailtrap.Inbound;


/// <summary>
/// Represents an inbound message resource.
/// </summary>
public interface IInboundMessageResource : IRestResource
{
    /// <summary>
    /// Gets details of the message (with body and attachment download URLs), represented by the current resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Requested message details.
    /// </returns>
    public Task<InboundMessage> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Permanently deletes the message, represented by the current resource instance.
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
    /// Replies to the message (to the original sender). Sends a real email.
    /// </summary>
    ///
    /// <param name="request">
    /// The reply body.
    /// </param>
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// The send result, containing the sent message UUIDs.
    /// </returns>
    public Task<SendMessageResult> Reply(ReplyInboundMessageRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Replies to the message and copies the original's other recipients. Sends a real email.
    /// </summary>
    ///
    /// <param name="request">
    /// The reply body.
    /// </param>
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// The send result, containing the sent message UUIDs.
    /// </returns>
    public Task<SendMessageResult> ReplyAll(ReplyInboundMessageRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Forwards the message to new recipients (at least one <c>To</c> is required). Sends a real email.
    /// </summary>
    ///
    /// <param name="request">
    /// The forward body.
    /// </param>
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// The send result, containing the sent message UUIDs.
    /// </returns>
    public Task<SendMessageResult> Forward(ForwardInboundMessageRequest request, CancellationToken cancellationToken = default);
}
