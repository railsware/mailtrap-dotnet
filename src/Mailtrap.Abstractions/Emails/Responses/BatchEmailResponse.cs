namespace Mailtrap.Emails.Responses;


/// <summary>
/// Represents batch send email response object.
/// </summary>
public sealed record BatchEmailResponse : EmailResponse
{
    /// <summary>
    /// Gets a collection of individual message responses that have been sent.
    /// </summary>
    ///
    /// <value>
    /// A collection of individual message responses that have been sent.
    /// </value>
    ///
    /// <remarks>
    /// The order of results is the same as the original messages.
    /// </remarks>
    [JsonPropertyName("responses")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<SendEmailResponse> Responses { get; private set; } = [];


    internal static BatchEmailResponse CreateSuccess(params SendEmailResponse[] responses)
    {
        return new BatchEmailResponse
        {
            Success = true,
            Responses = responses
        };
    }
}
