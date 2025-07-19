namespace Mailtrap.Core.Rest;


/// <summary>
/// Abstract REST resource implementation
/// </summary>
internal abstract class RestResource : IRestResource
{
    protected IRestResourceCommandFactory RestResourceCommandFactory { get; }

    public Uri ResourceUri { get; }


    protected RestResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
    {
        Ensure.NotNull(restResourceCommandFactory, nameof(restResourceCommandFactory));
        Ensure.NotNull(resourceUri, nameof(resourceUri));

        RestResourceCommandFactory = restResourceCommandFactory;
        ResourceUri = resourceUri;
    }


    protected Task<TResult> Get<TResult>(CancellationToken cancellationToken = default)
        => Get<TResult>(ResourceUri, cancellationToken);

    protected Task<TResult> Get<TResult>(string segment, CancellationToken cancellationToken = default)
        => Get<TResult>(ResourceUri.Append(segment), cancellationToken);


    protected Task<IList<TResult>> GetList<TResult>(CancellationToken cancellationToken = default)
        => GetList<TResult>(ResourceUri, cancellationToken);

    protected Task<IList<TResult>> GetList<TResult>(Uri uri, CancellationToken cancellationToken = default)
        => Get<IList<TResult>>(uri, cancellationToken);


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

        return RestResourceCommandFactory
            .CreatePatchWithContent<TRequest, TResult>(ResourceUri, request)
            .Execute(cancellationToken);
    }

    protected async Task<TResult> Delete<TResult>(CancellationToken cancellationToken = default)
        => await RestResourceCommandFactory
            .CreateDelete<TResult>(ResourceUri)
            .Execute(cancellationToken)
            .ConfigureAwait(false);


    private Task<TResult> Get<TResult>(Uri uri, CancellationToken cancellationToken = default)
        => RestResourceCommandFactory
            .CreateGet<TResult>(uri)
            .Execute(cancellationToken);
}
