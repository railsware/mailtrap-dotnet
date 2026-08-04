namespace Mailtrap.Inbound;


/// <summary>
/// Represents the inbound message collection resource for an inbox.
/// </summary>
public interface IInboundMessageCollectionResource : IRestResource
{
    /// <summary>
    /// Lists received messages in the inbox, with cursor-based pagination.
    /// </summary>
    ///
    /// <param name="lastId">
    /// Optional pagination cursor from a previous response's <c>last_id</c>.
    /// <see langword="null"/> for the first page.
    /// </param>
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// A page of messages, with total count and next-page cursor.
    /// </returns>
    public Task<InboundMessagesListResponse> List(string? lastId = null, CancellationToken cancellationToken = default);
}
