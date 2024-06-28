// -----------------------------------------------------------------------
// <copyright file="MailtrapClientConfigurationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Mailtrap.Configuration.Validators;

namespace Mailtrap.Configuration;


internal sealed class MailtrapClientConfigurationProvider : IMailtrapClientConfigurationProvider
{
    public MailtrapClientOptions Configuration { get; }

    public MailtrapClientConfigurationProvider(IOptions<MailtrapClientOptions> options)
    {
        Ensure.NotNull(options, nameof(options));

        var validationResult = MailtrapClientOptionsValidator.Instance.Validate(options.Value);

        if (!validationResult.IsValid)
        {
            throw new ArgumentException($"Invalid request data:\n{validationResult.ToString("\n")}");
        }

        Configuration = options.Value;
    }
}
