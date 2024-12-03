// -----------------------------------------------------------------------
// <copyright file="IHttpClientProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Http;


internal interface IHttpClientProvider
{
    /// <summary>
    /// Gets <see cref="HttpClient"/> instance.
    /// </summary>
    /// 
    /// <value>
    /// <see cref="HttpClient"/> instance.
    /// </value>
    ///
    /// <remarks>
    /// Instance lifetime depends on provider implementation,
    /// thus should not be assumed to be a singleton.<br />
    /// Meanwhile, consumers should not dispose it, since it <i>can</i> be a singleton
    /// and shared across calling parties.
    /// </remarks>
    HttpClient Client { get; }
}
