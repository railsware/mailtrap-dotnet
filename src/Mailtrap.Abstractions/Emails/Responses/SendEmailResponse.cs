namespace Mailtrap.Emails.Responses;


/// <summary>
/// Represents send email response object.
/// </summary>
public sealed record SendEmailResponse
{
    /// <summary>
    /// Gets an empty response object.
    /// </summary>
    ///
    /// <value>
    /// Empty response object.
    /// </value>
    public static SendEmailResponse Empty { get; } = new(success: false, errorData: ["Empty response."]);

    /// <summary>
    /// Gets a flag, indicating whether request succeeded or failed and response contains error(s).
    /// </summary>
    ///
    /// <value>
    /// <see langword="false"/> when request failed and response contains error(s).<br/>
    /// <see langword="true"/> when request succeeded.
    /// </value>
    [JsonPropertyName("success")]
    [JsonPropertyOrder(1)]
    public bool Success { get; } = false;

    /// <summary>
    /// Gets errors, associated with the response.
    /// </summary>
    ///
    /// <value>
    /// Collection of error(s) details.
    /// </value>
    [JsonPropertyName("errors")]
    [JsonPropertyOrder(2)]
    public IList<string> ErrorData { get; }

    /// <summary>
    /// Gets a collection of IDs of emails that have been sent.
    /// </summary>
    ///
    /// <value>
    /// A collection of IDs of emails that have been sent.
    /// </value>
    [JsonPropertyName("message_ids")]
    [JsonPropertyOrder(3)]
    public IList<string> MessageIds { get; }


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="success">
    /// Flag, indicating whether request succeeded or failed and response contains error(s).
    /// </param>
    /// 
    /// <param name="messageIds">
    /// A collection of message IDs.
    /// </param>
    /// 
    /// <param name="errorData">
    /// Errors to associate with the response.
    /// </param>
    public SendEmailResponse(
        bool success,
        IList<string>? messageIds = default,
        IList<string>? errorData = default)
    {
        Success = success;
        MessageIds = messageIds ?? [];
        ErrorData = errorData ?? [];
    }
}
