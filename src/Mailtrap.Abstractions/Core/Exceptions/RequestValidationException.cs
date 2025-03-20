namespace Mailtrap.Core.Exceptions;


/// <summary>
/// Exception which is thrown when the request passed to the Mailtrap API has an invalid format.
/// </summary>
public sealed class RequestValidationException : MailtrapApiException
{
    /// <summary>
    /// Gets request validation result.
    /// </summary>
    ///
    /// <value>
    /// Request validation result.
    /// </value>
    public ValidationResult ValidationResult { get; }


    /// <summary>
    /// <inheritdoc cref="MailtrapApiException(Uri, HttpMethod)" path="/summary"/><br />
    /// Additionally provides <paramref name="validationResult"/> for request.
    /// </summary>
    /// 
    /// <param name="resourceUri">
    /// <inheritdoc cref="MailtrapApiException(Uri, HttpMethod)" path="/param[@name='requestUri']"/>
    /// </param>
    ///
    /// <param name="httpMethod">
    /// <inheritdoc cref="MailtrapApiException(Uri, HttpMethod)" path="/param[@name='httpMethod']"/>
    /// </param>
    /// 
    /// <param name="validationResult">
    /// Validation result for request.
    /// </param>
    ///
    /// <inheritdoc cref="MailtrapApiException(Uri, HttpMethod)" path="/exception"/>
    /// <exception cref="ArgumentNullException">
    /// When the <paramref name="validationResult"/> is <see langword="null"/>.
    /// </exception>
    public RequestValidationException(
        Uri resourceUri,
        HttpMethod httpMethod,
        ValidationResult validationResult)
        : base(resourceUri, httpMethod, FormatMessage(validationResult))
    {
        Ensure.NotNull(validationResult, nameof(validationResult));

        ValidationResult = validationResult;
    }


    private static string FormatMessage(ValidationResult validationResult)
        => $"Request has an invalid format: {validationResult}";
}
