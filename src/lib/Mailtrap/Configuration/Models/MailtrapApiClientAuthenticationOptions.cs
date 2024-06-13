// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientAuthenticationOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Configuration.Models;


public record MailtrapApiClientAuthenticationOptions
{
    public static MailtrapApiClientAuthenticationOptions Empty { get; } = new(string.Empty);


    public string ApiToken { get; }


    public MailtrapApiClientAuthenticationOptions(string apiToken)
    {
        Ensure.NotNull(apiToken, nameof(apiToken));

        ApiToken = apiToken;
    }
}
