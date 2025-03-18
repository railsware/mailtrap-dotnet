namespace Mailtrap.Inboxes.Requests;


/// <summary>
/// Generic request object for inbox CRUD operations.
/// </summary>
internal record InboxRequestDto<T> where T : InboxRequest
{
    /// <summary>
    /// Gets or sets inbox details.
    /// </summary>
    /// 
    /// <value>
    /// Inbox details.
    /// </value>
    [JsonPropertyName("inbox")]
    [JsonPropertyOrder(1)]
    public T? Inbox { get; set; }
}
