namespace Mailtrap.Suppressions.Responses;


/// <summary>
/// Response DTO that unwraps a single suppression from the <c>data</c> envelope.
/// </summary>
internal sealed record SuppressionResponseDto
{
    /// <summary>
    /// Gets the suppression.
    /// </summary>
    ///
    /// <value>
    /// Suppression.
    /// </value>
    [JsonPropertyName("data")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public Suppression Suppression { get; } = new();
}
