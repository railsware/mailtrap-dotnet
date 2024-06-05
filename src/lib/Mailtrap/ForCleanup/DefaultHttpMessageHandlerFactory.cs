// -----------------------------------------------------------------------
// <copyright file="DefaultHttpMessageHandlerFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.ForCleanup;


internal partial class DefaultHttpMessageHandlerFactory : IHttpMessageHandlerFactory
{
#if NETSTANDARD2_0
    public virtual HttpMessageHandler GetHandler() => new HttpClientHandler();
#else
    private readonly TimeSpan _connectionLifetime;


    internal DefaultHttpMessageHandlerFactory(TimeSpan connectionLifetime)
    {
        _connectionLifetime = connectionLifetime;
    }

    internal DefaultHttpMessageHandlerFactory() : this(TimeSpan.FromMinutes(5)) { }


    public virtual HttpMessageHandler GetHandler()
    {
        // Using limited connections lifetime to avoid issues with port exhausting and DNS caching issues.
        // https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
        return new SocketsHttpHandler
        {
            PooledConnectionLifetime = _connectionLifetime
        };
    }
#endif
}
