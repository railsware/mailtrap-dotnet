// -----------------------------------------------------------------------
// <copyright file="IMailtrapClientConfigurationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


/// <summary>
/// Provides Mailtrap API client configuration.
/// </summary>
internal interface IMailtrapClientConfigurationProvider
{
    /// <summary>
    /// Mailtrap API client configuration.
    /// </summary>
    MailtrapClientOptions Configuration { get; }
}
