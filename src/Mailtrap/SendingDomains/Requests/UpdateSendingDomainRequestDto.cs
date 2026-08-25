namespace Mailtrap.SendingDomains.Requests;


/// <summary>
/// Request DTO that wraps <see cref="UpdateSendingDomainRequest"/> in the <c>sending_domain</c> envelope expected by the API.
/// </summary>
internal sealed record UpdateSendingDomainRequestDto
{
    [JsonPropertyName("sending_domain")]
    [JsonPropertyOrder(1)]
    public UpdateSendingDomainRequest Domain { get; }


    public UpdateSendingDomainRequestDto(UpdateSendingDomainRequest domain)
    {
        Ensure.NotNull(domain, nameof(domain));

        Domain = domain;
    }
}
