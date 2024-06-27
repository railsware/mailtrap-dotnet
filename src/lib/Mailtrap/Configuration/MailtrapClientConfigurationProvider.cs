// -----------------------------------------------------------------------
// <copyright file="MailtrapClientConfigurationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


internal sealed class MailtrapClientConfigurationProvider : IMailtrapClientConfigurationProvider
{
    public MailtrapClientOptions Configuration { get; }

    public MailtrapClientConfigurationProvider(IOptions<MailtrapClientOptions> options)
    {
        Ensure.NotNull(options, nameof(options));

        Configuration = options.Value;
    }
}
