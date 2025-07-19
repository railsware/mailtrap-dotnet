namespace Mailtrap.Core.Exceptions;


/// <summary>
/// Exception which is thrown when the request sent to the Mailtrap API was not valid.
/// </summary>
public sealed class HttpRequestFailedException : MailtrapApiException
{
    /// <summary>
    /// Gets HTTP status code that was returned.
    /// </summary>
    ///
    /// <value>
    /// HTTP status code that was returned.
    /// </value>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Gets HTTP status reason that was returned.
    /// </summary>
    ///
    /// <value>
    /// HTTP status reason that was returned.
    /// </value>
    public string Reason { get; }


    /// <summary>
    /// <inheritdoc cref="MailtrapApiException(Uri, HttpMethod)" path="/summary"/><br />
    /// Additionally provides <paramref name="statusCode"/> and content which were received as a response.
    /// </summary>
    /// 
    /// <param name="requestUri">
    /// <inheritdoc cref="MailtrapApiException(Uri, HttpMethod)" path="/param[@name='requestUri']"/>
    /// </param>
    ///
    /// <param name="httpMethod">
    /// <inheritdoc cref="MailtrapApiException(Uri, HttpMethod)" path="/param[@name='httpMethod']"/>
    /// </param>
    /// 
    /// <param name="statusCode">
    /// HTTP status code that was returned.
    /// </param>
    /// 
    /// <param name="reason">
    /// HTTP status reason that was returned.
    /// </param>
    ///
    /// <param name="message">
    /// Text representation of the error.
    /// </param>
    /// 
    /// <inheritdoc cref="MailtrapApiException(Uri, HttpMethod)" path="/exception"/>
    /// <exception cref="ArgumentNullException">
    /// When the <paramref name="statusCode"/> is <see langword="null"/>.
    /// </exception>
    public HttpRequestFailedException(
        Uri requestUri,
        HttpMethod httpMethod,
        HttpStatusCode statusCode,
        string reason,
        string? message = null)
        : base(requestUri, httpMethod, FormatMessage(statusCode, message))
    {
        Ensure.NotNull(statusCode, nameof(statusCode));

        StatusCode = statusCode;
        Reason = reason;
    }


    private static string FormatMessage(HttpStatusCode statusCode, string? message)
    {
        var result = $"API call failed with status '{statusCode} ({statusCode.GetHashCode()})'.";

        return string.IsNullOrEmpty(message) ? result : $"{result} Error details: '{message}'.";
    }
}
