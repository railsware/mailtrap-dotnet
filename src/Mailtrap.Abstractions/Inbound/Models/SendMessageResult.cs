namespace Mailtrap.Inbound.Models;


/// <summary>
/// Result of a reply, reply-all, or forward operation (each sends a real email).
/// </summary>
public sealed record SendMessageResult
{
    /// <summary>
    /// Gets the UUIDs assigned by the Email API to the sent message, one per recipient.
    /// </summary>
    ///
    /// <value>
    /// UUIDs of the sent message, one per recipient.
    /// </value>
    [JsonPropertyName("message_ids")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<string> MessageIds { get; } = [];
}
