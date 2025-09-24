namespace Mailtrap.ContactEvents.Models;

/// <summary>
/// Represents Contacts Event details.
/// </summary>
public sealed record ContactsEvent
{
    /// <summary>
    /// Gets Contact identifier.
    /// </summary>
    ///
    /// <value>
    /// Contact identifier.
    /// </value>
    [JsonPropertyName("contact_id")]
    public string ContactId { get; set; } = string.Empty;

    /// <summary>
    /// Gets Contact email.
    /// </summary>
    ///
    /// <value>
    /// Contact email.
    /// </value>
    [JsonPropertyName("contact_email")]
    public string ContactEmail { get; set; } = string.Empty;

    /// <summary>
    /// Gets Contacts Event name.
    /// </summary>
    ///
    /// <value>
    /// Contacts Event name.
    /// </value>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets Contacts event params.
    /// </summary>
    ///
    /// <value>
    /// Contacts event params.
    /// </value>
    [JsonPropertyName("params")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IDictionary<string, object?> Params { get; } = new Dictionary<string, object?>();
}
