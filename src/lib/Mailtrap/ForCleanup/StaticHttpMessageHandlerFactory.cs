// -----------------------------------------------------------------------
// <copyright file="StaticHttpMessageHandlerFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.ForCleanup;


internal class StaticHttpMessageHandlerFactory : IHttpMessageHandlerFactory, IDisposable
{
    private readonly HttpMessageHandler _messageHandler;


    internal StaticHttpMessageHandlerFactory(HttpMessageHandler messageHandler)
    {
        _messageHandler = messageHandler;
    }

    public virtual HttpMessageHandler GetHandler() => _messageHandler;

    public void Dispose() => _messageHandler.Dispose();
}
