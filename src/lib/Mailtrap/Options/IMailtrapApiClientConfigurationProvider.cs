// -----------------------------------------------------------------------
// <copyright file="IMailtrapApiClientConfigurationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Options;


public interface IMailtrapApiClientConfigurationProvider
{
    MailtrapApiClientOptions Configuration { get; }
}
