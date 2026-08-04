namespace Mailtrap.Inbound.Responses;


/// <summary>
/// Response for listing inbound messages.
/// </summary>
public sealed record InboundMessagesListResponse
{
    /// <summary>
    /// Gets the page of messages.
    /// </summary>
    ///
    /// <value>
    /// Page of messages.
    /// </value>
    [JsonPropertyName("data")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<InboundMessage> Data { get; } = [];

    /// <summary>
    /// Gets or sets the total number of messages in the inbox.
    /// </summary>
    ///
    /// <value>
    /// Total number of messages in the inbox.
    /// </value>
    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }

    /// <summary>
    /// Gets or sets the pagination cursor to pass as <c>lastId</c> for the next page,
    /// or <see langword="null"/> when there are no more pages.
    /// </summary>
    ///
    /// <value>
    /// Pagination cursor, or <see langword="null"/> when there are no more pages.
    /// </value>
    [JsonPropertyName("last_id")]
    public string? LastId { get; set; }
}
