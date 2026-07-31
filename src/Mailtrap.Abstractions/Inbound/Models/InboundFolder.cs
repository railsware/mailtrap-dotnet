namespace Mailtrap.Inbound.Models;


/// <summary>
/// Represents an inbound folder.
/// </summary>
public sealed record InboundFolder
{
    /// <summary>
    /// Gets or sets the folder identifier.
    /// </summary>
    ///
    /// <value>
    /// Folder identifier.
    /// </value>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the folder name.
    /// </summary>
    ///
    /// <value>
    /// Folder name.
    /// </value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
