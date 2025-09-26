namespace Mailtrap.Contacts.Responses;

/// <summary>
/// Generic response object for contact operations.
/// </summary>
public record ContactResponse
{
    /// <summary>
    /// Gets or sets created contact details.
    /// </summary>
    ///
    /// <value>
    /// Contact details.
    /// </value>
    [JsonPropertyName("data")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Contact Contact { get; set; } = new();
}
