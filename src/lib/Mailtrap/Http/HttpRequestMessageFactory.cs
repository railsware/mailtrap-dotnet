// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http;


/// <summary>
/// <see cref="IHttpRequestMessageFactory"/> default implementation.
/// </summary>
internal sealed class HttpRequestMessageFactory : IHttpRequestMessageFactory
{
    private readonly string _token;


    /// <summary>
    /// Default constructor.
    /// </summary>
    /// 
    /// <param name="options">
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="options"/> is <see langword="null"/>.
    /// </exception>
    public HttpRequestMessageFactory(IOptions<MailtrapClientOptions> options)
    {
        Ensure.NotNull(options, nameof(options));

        _token = options.Value.Authentication.ApiToken;
    }


    /// <inheritdoc/>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When any of provided <paramref name="method"/>, <paramref name="uri"/> or <paramref name="content"/>
    /// is <see langword="null"/>.
    /// </exception>
    public HttpRequestMessage Create(HttpMethod method, Uri uri, HttpContent content)
    {
        Ensure.NotNull(method, nameof(method));
        Ensure.NotNull(uri, nameof(uri));
        Ensure.NotNull(content, nameof(content));

        var request = new HttpRequestMessage(method, uri)
        {
            Content = content
        };

        return request
            .ConfigureAcceptHeader()
            .ConfigureUserAgentHeader()
            .ConfigureAuthorizationHeader(_token);
    }
}
