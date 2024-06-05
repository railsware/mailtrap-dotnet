// -----------------------------------------------------------------------
// <copyright file="OptionsMailtrapApiClientConfigurationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


internal sealed class OptionsMailtrapApiClientConfigurationProvider : IMailtrapApiClientConfigurationProvider
{
    public MailtrapApiClientOptions Configuration { get; }

    public OptionsMailtrapApiClientConfigurationProvider(IOptions<MailtrapApiClientOptions> options)
    {
        Configuration = options.Value;
    }
}
