// -----------------------------------------------------------------------
// <copyright file="RestResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Rest;


/// <summary>
/// Abstract REST resource implementation
/// </summary>
internal abstract class RestResource
{
    private volatile bool _deleted;


    protected IRestResourceCommandFactory RestResourceCommandFactory { get; }

    public Uri ResourceUri { get; }


    protected RestResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
    {
        Ensure.NotNull(restResourceCommandFactory, nameof(restResourceCommandFactory));
        Ensure.NotNull(resourceUri, nameof(resourceUri));

        RestResourceCommandFactory = restResourceCommandFactory;
        ResourceUri = resourceUri;
    }


    protected void EnsureNotDeleted()
    {
        if (_deleted)
        {
            throw new ResourceDeletedException(ResourceUri);
        }
    }


    protected Task<TResult> Get<TResult>(CancellationToken cancellationToken = default)
        => Get<TResult>(true, cancellationToken);

    protected Task<TResult> Get<TResult>(bool ensureNotDeleted, CancellationToken cancellationToken = default)
        => Get<TResult>(ResourceUri, ensureNotDeleted, cancellationToken);

    protected Task<TResult> Get<TResult>(string segment, CancellationToken cancellationToken = default)
        => Get<TResult>(segment, true, cancellationToken);

    protected Task<TResult> Get<TResult>(string segment, bool ensureNotDeleted, CancellationToken cancellationToken = default)
        => Get<TResult>(ResourceUri.Append(segment), ensureNotDeleted, cancellationToken);


    protected Task<IList<TResult>> GetList<TResult>(CancellationToken cancellationToken = default)
        => GetList<TResult>(null, cancellationToken);

    protected Task<IList<TResult>> GetList<TResult>(Uri? uri, CancellationToken cancellationToken = default)
        => Get<IList<TResult>>(uri ?? ResourceUri, false, cancellationToken);


    protected Task<TResult> Create<TRequest, TResult>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : class
    {
        Ensure.NotNull(request, nameof(request));

        return RestResourceCommandFactory
            .CreatePost<TRequest, TResult>(ResourceUri, request)
            .Execute(cancellationToken);
    }

    public Task<TResult> Update<TRequest, TResult>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : class
    {
        Ensure.NotNull(request, nameof(request));

        EnsureNotDeleted();

        return RestResourceCommandFactory
            .CreatePatchWithContent<TRequest, TResult>(ResourceUri, request)
            .Execute(cancellationToken);
    }

    protected async Task<TResult> Delete<TResult>(CancellationToken cancellationToken = default)
    {
        // TODO: Revisit resource deletion flow.
        //
        // Possible scenarios to consider:
        // - The resource was already deleted - should we throw or gracefully exit doing nothing?
        // - Another request starting while deletion request is in-flight.
        //
        // For now we just simply mark the resource as deleted after request completed successfully
        // without any concurrency considerations, except volatile constraint for the _deleted flag.

        EnsureNotDeleted();

        var result = await RestResourceCommandFactory
            .CreateDelete<TResult>(ResourceUri)
            .Execute(cancellationToken)
            .ConfigureAwait(false);

        _deleted = true;

        return result;
    }


    private Task<TResult> Get<TResult>(Uri uri, bool ensureNotDeleted, CancellationToken cancellationToken = default)
    {
        if (ensureNotDeleted)
        {
            EnsureNotDeleted();
        }

        return RestResourceCommandFactory
            .CreateGet<TResult>(uri)
            .Execute(cancellationToken);
    }
}
