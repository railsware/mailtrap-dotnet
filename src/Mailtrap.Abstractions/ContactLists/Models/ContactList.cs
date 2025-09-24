namespace Mailtrap.ContactLists.Models;

/// <summary>
/// Represents contact list details.
/// </summary>
public sealed record ContactList
{
    /// <summary>
    /// Gets or sets contact list identifier.
    /// </summary>
    ///
    /// <value>
    /// Contact list identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets contact list name.
    /// </summary>
    ///
    /// <value>
    /// Contact list name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(2)]
    public string Name { get; set; } = string.Empty;
}
