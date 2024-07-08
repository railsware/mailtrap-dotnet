// -----------------------------------------------------------------------
// <copyright file="HttpRequestMessageFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.Request;


/// <summary>
/// <see cref="IHttpRequestMessageFactory"/> default implementation.
/// </summary>
internal sealed class HttpRequestMessageFactory : IHttpRequestMessageFactory
{
    private readonly IList<IHttpRequestMessagePolicy> _requestPolicies;


    public HttpRequestMessageFactory(IEnumerable<IHttpRequestMessagePolicy> requestPolicies)
    {
        Ensure.NotNull(requestPolicies, nameof(requestPolicies));

        _requestPolicies = requestPolicies.ToList();
    }


    public async Task<HttpRequestMessage> CreateAsync(HttpMethod method, Uri uri, HttpContent content, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(method, nameof(method));
        Ensure.NotNull(uri, nameof(uri));
        Ensure.NotNull(content, nameof(content));

        var request = new HttpRequestMessage(method, uri)
        {
            Content = content
        };

        // Usage of Task.WhenAll() can lead to UB,
        // because different policies could set same properties,
        // and create race conditions in case of simultaneous updates
        foreach (var policy in _requestPolicies)
        {
            await policy
                .ApplyPolicyAsync(request, cancellationToken)
                .ConfigureAwait(false);
        }

        return request;
    }
}
