namespace Mailtrap.Core.Http.ResponseHandlers;


internal interface IHttpResponseHandler<T>
{
    public Task<T> ProcessResponse(CancellationToken cancellationToken = default);
}
