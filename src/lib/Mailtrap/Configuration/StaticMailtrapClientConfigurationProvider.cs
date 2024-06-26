// -----------------------------------------------------------------------
// <copyright file="StaticMailtrapClientConfigurationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


internal sealed class StaticMailtrapClientConfigurationProvider : IMailtrapClientConfigurationProvider
{
    public MailtrapClientOptions Configuration { get; }

    public StaticMailtrapClientConfigurationProvider(MailtrapClientOptions options)
    {
        Configuration = options;
    }
}
