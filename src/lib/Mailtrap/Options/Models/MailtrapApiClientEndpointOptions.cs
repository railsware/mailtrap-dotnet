// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Options.Models;


public abstract record MailtrapApiClientEndpointOptions
{
    public Uri BaseUrl { get; }


    protected MailtrapApiClientEndpointOptions(Uri baseUrl)
    {
        ExceptionHelpers.ThrowIfNull(baseUrl, nameof(baseUrl));

        BaseUrl = baseUrl;
    }

    protected MailtrapApiClientEndpointOptions(string baseUrl)
    {
        ExceptionHelpers.ThrowIfNullOrEmpty(baseUrl, nameof(baseUrl));

        BaseUrl = Uri.TryCreate(baseUrl, UriKind.Absolute, out var result)
            ? result
            : throw new ArgumentException("Invalid base URL format - absolute URL is expected", nameof(baseUrl));
    }
}
