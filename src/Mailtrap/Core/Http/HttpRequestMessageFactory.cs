namespace Mailtrap.Core.Http;


/// <summary>
/// <see cref="IHttpRequestMessageFactory"/> default implementation.
/// </summary>
internal sealed class HttpRequestMessageFactory : IHttpRequestMessageFactory
{
    private readonly string _token;
    private readonly IHttpRequestContentFactory _httpRequestContentFactory;


    /// <summary>
    /// Default constructor.
    /// </summary>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="options"/> is <see langword="null"/>.
    /// </exception>
    public HttpRequestMessageFactory(
        IOptions<MailtrapClientOptions> options,
        IHttpRequestContentFactory httpRequestContentFactory)
    {
        Ensure.NotNull(options, nameof(options));
        Ensure.NotNull(httpRequestContentFactory, nameof(httpRequestContentFactory));

        _token = options.Value.ApiToken;
        _httpRequestContentFactory = httpRequestContentFactory;
    }


    /// <inheritdoc/>
    public HttpRequestMessage Create(HttpMethod method, Uri uri)
        => CreateCore(method, uri);

    /// <inheritdoc/>
    public HttpRequestMessage CreateWithContent<T>(HttpMethod method, Uri uri, T? content = null) where T : class
        => CreateCore(method, uri, _httpRequestContentFactory.CreateStringContent(content));


    private HttpRequestMessage CreateCore(HttpMethod method, Uri uri, HttpContent? content = null)
    {
        Ensure.NotNull(method, nameof(method));
        Ensure.NotNull(uri, nameof(uri));

        var request = new HttpRequestMessage(method, uri)
        {
            Content = content
        };

        request
            .ConfigureAcceptHeader()
            .ConfigureUserAgentHeader()
            .ConfigureAuthorizationHeader(_token);

        return request;
    }
}
