// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientEndpointOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


public abstract record MailtrapApiClientEndpointOptions
{
    public Uri BaseUrl { get; }
    public string? HttpClientName { get; }


    protected MailtrapApiClientEndpointOptions(Uri baseUrl, string? httpClientName = default)
    {
        ExceptionHelpers.ThrowIfNull(baseUrl, nameof(baseUrl));

        BaseUrl = baseUrl;
        HttpClientName = httpClientName;
    }

    protected MailtrapApiClientEndpointOptions(string baseUrl, string? httpClientName = default)
        : this(baseUrl.ToAbsoluteUri(), httpClientName) { }
}
