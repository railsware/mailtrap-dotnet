namespace Mailtrap.Inbound;


/// <summary>
/// Represents access to the messages and threads of an inbound inbox.
/// </summary>
public interface IInboundInboxContentResource : IRestResource
{
    /// <summary>
    /// Gets the message collection resource for this inbox.
    /// </summary>
    ///
    /// <returns>
    /// Message collection resource for this inbox.
    /// </returns>
    public IInboundMessageCollectionResource Messages();

    /// <summary>
    /// Gets the resource for a specific message in this inbox, identified by <paramref name="messageId"/>.
    /// </summary>
    ///
    /// <param name="messageId">
    /// ID of the message to get resource for.
    /// </param>
    ///
    /// <returns>
    /// Resource for the message with the specified ID.
    /// </returns>
    public IInboundMessageResource Message(string messageId);

    /// <summary>
    /// Gets the thread collection resource for this inbox.
    /// </summary>
    ///
    /// <returns>
    /// Thread collection resource for this inbox.
    /// </returns>
    public IInboundThreadCollectionResource Threads();

    /// <summary>
    /// Gets the resource for a specific thread in this inbox, identified by <paramref name="threadId"/>.
    /// </summary>
    ///
    /// <param name="threadId">
    /// ID of the thread to get resource for.
    /// </param>
    ///
    /// <returns>
    /// Resource for the thread with the specified ID.
    /// </returns>
    public IInboundThreadResource Thread(string threadId);
}
