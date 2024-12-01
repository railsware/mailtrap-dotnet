// -----------------------------------------------------------------------
// <copyright file="IHttpResponseHandlerFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Http;


internal interface IHttpResponseHandlerFactory
{
    public IHttpResponseHandler<T> CreateJsonContentHandler<T>(HttpResponseMessage httpResponseMessage);
    public IHttpResponseHandler<string> CreatePlainTextContentHandler(HttpResponseMessage httpResponseMessage);
    public IHttpResponseHandler<HttpStatusCode> CreateStatusCodeHandler(HttpResponseMessage httpResponseMessage);
}
