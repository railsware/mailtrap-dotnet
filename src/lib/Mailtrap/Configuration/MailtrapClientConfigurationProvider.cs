// -----------------------------------------------------------------------
// <copyright file="MailtrapClientConfigurationProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


/// <summary>
/// Implementation of <see cref="IMailtrapClientConfigurationProvider"/>
/// that uses <see cref="IOptions{MailtrapClientOptions}"/> to provide Mailtrap API client configuration.
/// </summary>
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
