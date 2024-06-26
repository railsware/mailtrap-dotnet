// -----------------------------------------------------------------------
// <copyright file="OptionsMailtrapClientConfigurationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


internal sealed class OptionsMailtrapClientConfigurationProvider : IMailtrapClientConfigurationProvider
{
    public MailtrapClientOptions Configuration { get; }

    public OptionsMailtrapClientConfigurationProvider(IOptions<MailtrapClientOptions> options)
    {
        Configuration = options.Value;
    }
}
