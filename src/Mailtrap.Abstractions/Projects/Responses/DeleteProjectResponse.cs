namespace Mailtrap.Projects.Responses;


/// <summary>
/// Represents details for deleted project.
/// </summary>
public sealed record DeleteProjectResponse
{
    /// <summary>
    /// Gets the deleted project identifier.
    /// </summary>
    ///
    /// <value>
    /// Deleted project identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; set; }
}
