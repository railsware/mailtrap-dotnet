// -----------------------------------------------------------------------
// <copyright file="StaticMailtrapApiClientOptionsProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using Microsoft.Extensions.Options;


namespace Mailtrap.Options;


internal class DefaultMailtrapApiClientOptionsProvider : IMailtrapApiClientOptionsProvider
{
    public MailtrapApiClientOptions Options { get; private set; }

    public DefaultMailtrapApiClientOptionsProvider(IOptions<MailtrapApiClientOptions> options)
    {
        Options = options.Value;
    }
}
