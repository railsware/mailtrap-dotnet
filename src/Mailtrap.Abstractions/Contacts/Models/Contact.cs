namespace Mailtrap.Contacts.Models;

/// <summary>
/// Represents Contact details.
/// </summary>
public sealed record Contact
{
    /// <summary>
    /// Gets Contact identifier.
    /// </summary>
    ///
    /// <value>
    /// Contact identifier.
    /// </value>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets Contact email.
    /// </summary>
    ///
    /// <value>
    /// Contact email.
    /// </value>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets Contact fields.
    /// </summary>
    ///
    /// <value>
    /// Contact fields.
    /// </value>
    [JsonPropertyName("fields")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IDictionary<string, object> Fields { get; } = new Dictionary<string, object>();

    /// <summary>
    /// Gets Contact's list ids.
    /// </summary>
    ///
    /// <value>
    /// Contact's list ids.
    /// </value>
    [JsonPropertyName("list_ids")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<int> ListIds { get; } = [];

    /// <summary>
    /// Gets status of the contact.
    /// </summary>
    ///
    /// <value>
    /// Contact's status.
    /// </value>
    [JsonPropertyName("status")]
    public ContactStatus Status { get; set; } = ContactStatus.Unknown;

    /// <summary>
    /// Gets Contact creation date and time.
    /// </summary>
    ///
    /// <value>
    /// Contact creation date and time.
    /// </value>
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeToUnixMsNullableJsonConverter))]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// Gets Contact's update date and time.
    /// </summary>
    ///
    /// <value>
    /// Contact's update date and time.
    /// </value>
    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeToUnixMsNullableJsonConverter))]
    public DateTimeOffset? UpdatedAt { get; set; }
}
