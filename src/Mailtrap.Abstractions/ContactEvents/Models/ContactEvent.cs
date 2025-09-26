namespace Mailtrap.ContactEvents.Models;

/// <summary>
/// Represents Contact Event details.
/// </summary>
public sealed record ContactEvent
{
    /// <summary>
    /// Gets or sets Contact identifier.
    /// </summary>
    ///
    /// <value>
    /// Contact identifier.
    /// </value>
    [JsonPropertyName("contact_id")]
    public string ContactId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Contact email.
    /// </summary>
    ///
    /// <value>
    /// Contact email.
    /// </value>
    [JsonPropertyName("contact_email")]
    public string ContactEmail { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Contact Event name.
    /// </summary>
    ///
    /// <value>
    /// Contact Event name.
    /// </value>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets Contact event params.
    /// </summary>
    ///
    /// <value>
    /// Contact event params.
    /// </value>
    [JsonPropertyName("params")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IDictionary<string, object?> Params { get; } = new Dictionary<string, object?>();
}
