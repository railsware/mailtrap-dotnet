namespace Mailtrap.EmailCampaigns.Responses;


/// <summary>
/// Response DTO that unwraps a single email campaign from the <c>data</c> envelope.
/// </summary>
internal sealed record EmailCampaignResponseDto
{
    [JsonPropertyName("data")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public EmailCampaign EmailCampaign { get; } = new();
}
