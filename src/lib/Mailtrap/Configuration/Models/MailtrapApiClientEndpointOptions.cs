// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientEndpointOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Configuration.Models;


public record MailtrapApiClientEndpointOptions
{
    public Uri BaseUrl { get; }
    public string? HttpClientName { get; }


    public MailtrapApiClientEndpointOptions(Uri baseUrl, string? httpClientName = default)
    {
        Ensure.NotNull(baseUrl, nameof(baseUrl));

        BaseUrl = baseUrl;
        HttpClientName = httpClientName;
    }

    public MailtrapApiClientEndpointOptions(string baseUrl, string? httpClientName = default)
        : this(baseUrl.ToAbsoluteUri(), httpClientName) { }
}
