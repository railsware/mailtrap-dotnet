// -----------------------------------------------------------------------
// <copyright file="IRestResourceCommand.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Rest.Commands;


internal interface IRestResourceCommand<TResponse>
{
    public HttpMethod HttpMethod { get; }

    public Uri ResourceUri { get; }


    public Task<TResponse> Execute(CancellationToken cancellationToken = default);
}
