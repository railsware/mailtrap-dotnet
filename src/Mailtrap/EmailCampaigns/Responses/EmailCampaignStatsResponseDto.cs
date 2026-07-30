namespace Mailtrap.EmailCampaigns.Responses;


/// <summary>
/// Response DTO that unwraps email campaign statistics from the <c>data</c> envelope.
/// </summary>
internal sealed record EmailCampaignStatsResponseDto
{
    [JsonPropertyName("data")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public EmailCampaignStats Stats { get; } = new();
}
