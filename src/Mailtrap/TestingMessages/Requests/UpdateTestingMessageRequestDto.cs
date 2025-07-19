namespace Mailtrap.TestingMessages.Requests;


/// <summary>
/// Request object for updating message.
/// </summary>
internal sealed record UpdateTestingMessageRequestDto
{
    /// <summary>
    /// Gets or sets message details.
    /// </summary>
    ///
    /// <value>
    /// Message details.
    /// </value>
    [JsonPropertyName("message")]
    [JsonPropertyOrder(1)]
    public UpdateTestingMessageRequest? Message { get; set; }
}
