namespace Mailtrap.TrackingOptOuts.Responses;


/// <summary>
/// Response DTO that unwraps a single tracking opt-out from the <c>data</c> envelope.
/// </summary>
internal sealed record TrackingOptOutResponseDto
{
    /// <summary>
    /// Gets the tracking opt-out.
    /// </summary>
    ///
    /// <value>
    /// Tracking opt-out.
    /// </value>
    [JsonPropertyName("data")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public TrackingOptOut TrackingOptOut { get; } = new();
}
