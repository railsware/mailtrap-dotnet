// -----------------------------------------------------------------------
// <copyright file="IHttpResponseHandler.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Http.ResponseHandlers;


internal interface IHttpResponseHandler<T>
{
    public Task<T> ProcessResponse(CancellationToken cancellationToken = default);
}
