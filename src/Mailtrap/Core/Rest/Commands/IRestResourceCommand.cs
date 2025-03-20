namespace Mailtrap.Core.Rest.Commands;


internal interface IRestResourceCommand<TResponse>
{
    public HttpMethod HttpMethod { get; }

    public Uri ResourceUri { get; }


    public Task<TResponse> Execute(CancellationToken cancellationToken = default);
}
