// -----------------------------------------------------------------------
// <copyright file="StaticMailtrapApiClientConfigurationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


internal sealed class StaticMailtrapApiClientConfigurationProvider : IMailtrapApiClientConfigurationProvider
{
    public MailtrapApiClientOptions Configuration { get; }

    public StaticMailtrapApiClientConfigurationProvider(MailtrapApiClientOptions options)
    {
        Configuration = options;
    }
}
