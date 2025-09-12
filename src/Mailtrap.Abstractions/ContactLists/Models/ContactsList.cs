namespace Mailtrap.ContactLists.Models;

/// <summary>
/// Represents Contacts List details.
/// </summary>
public sealed record ContactsList
{
    /// <summary>
    /// Gets Contacts List identifier.
    /// </summary>
    ///
    /// <value>
    /// Contacts List identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    public long Id { get; set; }

    /// <summary>
    /// Gets Contacts List name.
    /// </summary>
    ///
    /// <value>
    /// Contacts List name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(2)]
    public string Name { get; set; } = string.Empty;
}
