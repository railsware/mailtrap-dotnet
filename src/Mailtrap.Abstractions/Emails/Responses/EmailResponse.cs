namespace Mailtrap.Emails.Responses;


/// <summary>
/// Represents base send email response object.
/// </summary>
public record EmailResponse
{
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
    [JsonInclude]
    public bool Success { get; protected set; } = false;

    /// <summary>
    /// Gets errors, associated with the response.
    /// </summary>
    ///
    /// <value>
    /// Collection of error(s) details.
    /// </value>
    [JsonPropertyName("errors")]
    [JsonPropertyOrder(2)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<string>? ErrorData { get; private set; } = [];


    internal static EmailResponse CreateSuccess()
    {
        return new EmailResponse
        {
            Success = true
        };
    }

    internal static EmailResponse CreateFailure(params string[] errors)
    {
        return new EmailResponse
        {
            Success = false,
            ErrorData = errors
        };
    }
}
