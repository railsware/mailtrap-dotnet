namespace Mailtrap.Core.Http;


internal interface IHttpResponseHandlerFactory
{
    public IHttpResponseHandler<T> CreateJsonContentHandler<T>(HttpResponseMessage httpResponseMessage);
    public IHttpResponseHandler<string> CreatePlainTextContentHandler(HttpResponseMessage httpResponseMessage);
    public IHttpResponseHandler<HttpStatusCode> CreateStatusCodeHandler(HttpResponseMessage httpResponseMessage);
}
