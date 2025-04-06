namespace Mailtrap.Emails.Responses;


/// <summary>
/// Represents send email response object.
/// </summary>
public sealed record SendEmailResponse : EmailResponse
{
    /// <summary>
    /// Gets a collection of IDs of emails that have been sent.
    /// </summary>
    ///
    /// <value>
    /// A collection of IDs of emails that have been sent.
    /// </value>
    [JsonPropertyName("message_ids")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<string> MessageIds { get; private set; } = [];


    internal static SendEmailResponse CreateSuccess(params string[] messageIds)
    {
        return new SendEmailResponse
        {
            Success = true,
            MessageIds = messageIds
        };
    }
}
