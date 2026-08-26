namespace Mailtrap.SendingDomains.Responses;


/// <summary>
/// Response DTO that unwraps company info from the <c>data</c> envelope.
/// </summary>
internal sealed record CompanyInfoResponseDto
{
    [JsonPropertyName("data")]
    [JsonPropertyOrder(1)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public CompanyInfo CompanyInfo { get; } = new();
}
