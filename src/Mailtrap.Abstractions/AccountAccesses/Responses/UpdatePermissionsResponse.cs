namespace Mailtrap.AccountAccesses.Responses;


/// <summary>
/// Represents details of updated account access permissions.
/// </summary>
public sealed record UpdatePermissionsResponse
{
    /// <summary>
    /// Gets the message about successful update of permissions.
    /// </summary>
    ///
    /// <value>
    /// Message about successful update of permissions.
    /// </value>
    [JsonPropertyName("message")]
    [JsonPropertyOrder(1)]
    public string? Message { get; set; }
}
