namespace Mailtrap.SendingDomains.Requests;


/// <summary>
/// Request object for creating sending domain.
/// </summary>
internal sealed record CreateSendingDomainRequestDto
{
    /// <summary>
    /// Gets or sets sending domain request payload.
    /// </summary>
    ///
    /// <value>
    /// Sending domain request payload.
    /// </value>
    [JsonPropertyName("sending_domain")]
    [JsonPropertyOrder(1)]
    public CreateSendingDomainRequest? Domain { get; set; }
}
