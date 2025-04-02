namespace Mailtrap.Emails.Responses;


/// <summary>
/// Represents batch send email response object.
/// </summary>
public sealed record BatchSendEmailResponse
{
    /// <summary>
    /// Gets a flag, indicating whether the was a general error.
    /// </summary>
    ///
    /// <value>
    /// <see langword="false"/> when request failed.<br/>
    /// <see langword="true"/> when request succeeded.
    /// </value>
    ///
    /// <remarks>
    /// When <see langword="false"/>, you should check the <see cref="ErrorData"/> array for information.<br />
    /// When <see langword="true"/>, you should check individual message status in the <see cref="Responses"/>.
    /// </remarks>
    [JsonPropertyName("success")]
    [JsonPropertyOrder(1)]
    [JsonInclude]
    public bool Success { get; private set; } = false;

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
    [JsonPropertyOrder(2)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<SendEmailResponse> Responses { get; } = [];

    /// <summary>
    /// Gets general errors, associated with the response.
    /// </summary>
    ///
    /// <value>
    /// Collection of error(s) details.
    /// </value>
    [JsonPropertyName("errors")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<string>? ErrorData { get; } = [];
}
