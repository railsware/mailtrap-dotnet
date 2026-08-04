namespace Mailtrap.Inbound.Models;


/// <summary>
/// Represents a conversation thread.<br/>
/// <see cref="Messages"/> is populated on get-by-id; list items carry only the
/// summary fields.
/// </summary>
public sealed record InboundThread
{
    /// <summary>
    /// Gets or sets the thread identifier.
    /// </summary>
    ///
    /// <value>
    /// Thread identifier.
    /// </value>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the subject of the thread's root message.
    /// </summary>
    ///
    /// <value>
    /// Subject of the thread's root message.
    /// </value>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// Gets or sets the number of accessible messages in the thread.
    /// </summary>
    ///
    /// <value>
    /// Number of accessible messages in the thread.
    /// </value>
    [JsonPropertyName("message_count")]
    public int? MessageCount { get; set; }

    /// <summary>
    /// Gets or sets the combined size of the accessible messages, in bytes.
    /// </summary>
    ///
    /// <value>
    /// Combined size of the accessible messages, in bytes.
    /// </value>
    [JsonPropertyName("size")]
    public int? Size { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the thread's first message.
    /// </summary>
    ///
    /// <value>
    /// Timestamp of the thread's first message.
    /// </value>
    [JsonPropertyName("first_message_at")]
    public DateTimeOffset? FirstMessageAt { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the thread's last received message.
    /// </summary>
    ///
    /// <value>
    /// Timestamp of the thread's last received message.
    /// </value>
    [JsonPropertyName("last_received_at")]
    public DateTimeOffset? LastReceivedAt { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the thread's last sent message.
    /// </summary>
    ///
    /// <value>
    /// Timestamp of the thread's last sent message.
    /// </value>
    [JsonPropertyName("last_sent_at")]
    public DateTimeOffset? LastSentAt { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the thread's last activity.
    /// </summary>
    ///
    /// <value>
    /// Timestamp of the thread's last activity.
    /// </value>
    [JsonPropertyName("last_activity_at")]
    public DateTimeOffset? LastActivityAt { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the thread's last message.
    /// </summary>
    ///
    /// <value>
    /// Identifier of the thread's last message.
    /// </value>
    [JsonPropertyName("last_message_id")]
    public string? LastMessageId { get; set; }

    /// <summary>
    /// Gets the distinct sender addresses across the thread.
    /// </summary>
    ///
    /// <value>
    /// Distinct sender addresses.
    /// </value>
    [JsonPropertyName("senders")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<string> Senders { get; } = [];

    /// <summary>
    /// Gets the distinct recipient addresses across the thread.
    /// </summary>
    ///
    /// <value>
    /// Distinct recipient addresses.
    /// </value>
    [JsonPropertyName("recipients")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<string> Recipients { get; } = [];

    /// <summary>
    /// Gets the attachments across the thread.
    /// </summary>
    ///
    /// <value>
    /// Attachments across the thread.
    /// </value>
    [JsonPropertyName("attachments")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<InboundAttachment> Attachments { get; } = [];

    /// <summary>
    /// Gets the messages in the thread, oldest first (get-by-id only).
    /// </summary>
    ///
    /// <value>
    /// Messages in the thread.
    /// </value>
    [JsonPropertyName("messages")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<InboundThreadMessage> Messages { get; } = [];
}
