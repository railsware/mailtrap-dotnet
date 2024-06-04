// -----------------------------------------------------------------------
// <copyright file="StaticMailtrapApiClientOptionsProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Options;


internal class StaticMailtrapApiClientOptionsProvider : IMailtrapApiClientOptionsProvider
{
    public MailtrapApiClientOptions Options { get; private set; }

    public StaticMailtrapApiClientOptionsProvider(MailtrapApiClientOptions options)
    {
        Options = options;
    }
}
