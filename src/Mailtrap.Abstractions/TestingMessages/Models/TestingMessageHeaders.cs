namespace Mailtrap.TestingMessages.Models;


/// <summary>
/// Represents headers details for the message.
/// </summary>
public sealed record TestingMessageHeaders
{
    /// <summary>
    /// Gets a collection of the message headers.
    /// </summary>
    ///
    /// <value>
    /// Collection of the message headers.
    /// </value>
    [JsonPropertyName("headers")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();
}
