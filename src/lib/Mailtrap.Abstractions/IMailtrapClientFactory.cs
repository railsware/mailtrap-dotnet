// -----------------------------------------------------------------------
// <copyright file="IMailtrapClientFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap;


/// <summary>
/// Factory to spawn <see cref="IMailtrapClient"/> instances.
/// <para>
/// Primary use case is for scenarios when usage of DI container is not possible or desired.
/// </para>
/// </summary>
public interface IMailtrapClientFactory : IDisposable
{
    /// <summary>
    /// Creates new instance of <see cref="IMailtrapClient"/>.
    /// <para>
    /// Each call to this method is guaranteed to return a new instance of <see cref="IMailtrapClient"/>.
    /// </para>
    /// </summary>
    /// <returns>New <see cref="IMailtrapClient"/> instance.</returns>
    IMailtrapClient CreateClient();
}
