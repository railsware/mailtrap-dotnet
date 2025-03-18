namespace Mailtrap.Projects.Models;


/// <summary>
/// Represents project share links.
/// </summary>
public sealed record ProjectShareLinks
{
    /// <summary>
    /// Gets a sharing link for admin.
    /// </summary>
    ///
    /// <value>
    /// Sharing link for admin.
    /// </value>
    [JsonPropertyName("admin")]
    [JsonPropertyOrder(1)]
    public Uri? Admin { get; set; }

    /// <summary>
    /// Gets a sharing link for viewer.
    /// </summary>
    ///
    /// <value>
    /// Sharing link for viewer.
    /// </value>
    [JsonPropertyName("viewer")]
    [JsonPropertyOrder(2)]
    public Uri? Viewer { get; set; }
}
