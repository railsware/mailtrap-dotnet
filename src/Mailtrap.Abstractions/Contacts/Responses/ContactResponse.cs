namespace Mailtrap.Contacts.Responses;

/// <summary>
/// Generic response object for contact operations.
/// </summary>
public record ContactResponse
{
    /// <summary>
    /// Gets created contact data.
    /// </summary>
    ///
    /// <value>
    /// Contact data.
    /// </value>
    [JsonPropertyName("data")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Contact Contact { get; set; } = new();
}
