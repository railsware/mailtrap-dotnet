// -----------------------------------------------------------------------
// <copyright file="IMailtrapApiClientConfigurationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


/// <summary>
/// Provides Mailtrap API client configuration.
/// </summary>
public interface IMailtrapApiClientConfigurationProvider
{
    /// <summary>
    /// Mailtrap API client configuration.
    /// </summary>
    MailtrapApiClientOptions Configuration { get; }
}
