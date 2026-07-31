namespace Mailtrap.Inbound.Requests;


/// <summary>
/// Request object for creating an inbound folder.
/// </summary>
public sealed record CreateInboundFolderRequest
{
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
