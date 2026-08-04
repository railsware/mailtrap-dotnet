namespace Mailtrap.Inbound.Requests;


/// <summary>
/// Request object for updating an inbound folder.
/// </summary>
public sealed record UpdateInboundFolderRequest
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
