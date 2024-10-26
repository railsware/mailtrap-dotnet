// -----------------------------------------------------------------------
// <copyright file="RestResourceCommandWithRequest.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Rest.Commands;


/// <summary>
/// </summary>
internal abstract class RestResourceCommandWithRequest<TRequest, TResponse>
    : RestResourceCommand<TResponse>
    where TRequest : class
{
    protected readonly TRequest _request;


    public RestResourceCommandWithRequest(
        IHttpClientFactory httpClientFactory,
        IHttpRequestMessageFactory httpRequestMessageFactory,
        IHttpResponseHandlerFactory httpResponseHandlerFactory,
        Uri resourceUri,
        TRequest request)
        : base(
            httpClientFactory,
            httpRequestMessageFactory,
            httpResponseHandlerFactory,
            resourceUri)
    {
        ValidateRequest(request);

        _request = request;
    }


    private static void ValidateRequest(TRequest request)
    {
        Ensure.NotNull(request, nameof(request));

        if (request is IValidatable validatable)
        {
            validatable.Validate().EnsureValidity(nameof(request));
        }
    }
}
