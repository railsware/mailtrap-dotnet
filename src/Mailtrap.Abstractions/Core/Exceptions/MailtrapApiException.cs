namespace Mailtrap.Core.Exceptions;


/// <summary>
/// Generic exception with additional API call details.
/// </summary>
public abstract class MailtrapApiException : MailtrapException
{
    /// <summary>
    /// Gets API endpoint that thrown exception.
    /// </summary>
    ///
    /// <value>
    /// API endpoint that thrown exception.
    /// </value>
    public Uri RequestUri { get; }

    /// <summary>
    /// Gets HTTP method that thrown exception.
    /// </summary>
    ///
    /// <value>
    /// HTTP method that thrown exception.
    /// </value>
    public HttpMethod HttpMethod { get; }


    /// <summary>
    /// Initializes a new instance of the exception with failed API details,
    /// defined by <paramref name="requestUri"/> and <paramref name="httpMethod"/>.
    /// </summary>
    ///
    /// <param name="requestUri">
    /// API endpoint that thrown exception.
    /// </param>
    /// 
    /// <param name="httpMethod">
    /// HTTP method that thrown exception.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When the <paramref name="requestUri"/> or <paramref name="httpMethod"/> is <see langword="null"/>.
    /// </exception>
    protected MailtrapApiException(Uri requestUri, HttpMethod httpMethod)
        : base()
    {
        Ensure.NotNull(requestUri, nameof(requestUri));
        Ensure.NotNull(httpMethod, nameof(httpMethod));

        RequestUri = requestUri;
        HttpMethod = httpMethod;
    }

    /// <summary>
    /// Initializes a new instance of the exception with failed API details,
    /// defined by <paramref name="requestUri"/> and <paramref name="httpMethod"/>,
    /// with specified error <paramref name="message"/>.
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
    /// <param name="message">
    /// <inheritdoc cref="MailtrapException(string)" path="/param[@name='message']"/>
    /// </param>
    /// 
    /// <inheritdoc cref="MailtrapApiException(Uri, HttpMethod)" path="/exception"/>
    protected MailtrapApiException(Uri requestUri, HttpMethod httpMethod, string message)
        : base(message)
    {
        Ensure.NotNull(requestUri, nameof(requestUri));
        Ensure.NotNull(httpMethod, nameof(httpMethod));

        RequestUri = requestUri;
        HttpMethod = httpMethod;
    }

    /// <summary>
    /// Initializes a new instance of the exception with failed API details,
    /// defined by <paramref name="requestUri"/> and <paramref name="httpMethod"/>,
    /// with specified error <paramref name="message"/> and a reference to the <paramref name="innerException"/>,
    /// that is the cause of this exception.
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
    /// <param name="message">
    /// <inheritdoc cref="MailtrapException(string, Exception)" path="/param[@name='message']"/>
    /// </param>
    ///
    /// <param name="innerException">
    /// <inheritdoc cref="MailtrapException(string, Exception)" path="/param[@name='innerException']"/>
    /// </param>
    ///
    /// <inheritdoc cref="MailtrapApiException(Uri, HttpMethod)" path="/exception"/>
    protected MailtrapApiException(Uri requestUri, HttpMethod httpMethod, string message, Exception innerException)
        : base(message, innerException)
    {
        Ensure.NotNull(requestUri, nameof(requestUri));
        Ensure.NotNull(httpMethod, nameof(httpMethod));

        RequestUri = requestUri;
        HttpMethod = httpMethod;
    }
}
