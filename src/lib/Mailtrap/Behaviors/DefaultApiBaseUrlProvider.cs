// -----------------------------------------------------------------------
// <copyright file="DefaultApiBaseUrlProvider.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Behaviors;


/// <summary>
/// Default implementation of <see cref="IApiBaseUrlProvider"/> that simply provides preconfigured static base URL value.
/// </summary>
internal class DefaultApiBaseUrlProvider : IApiBaseUrlProvider
{
    public Uri SendEmailHost { get; }


    internal DefaultApiBaseUrlProvider(string url)
    {
        ExceptionHelpers.ThrowIfNullOrEmpty(url, nameof(url));

        SendEmailHost = Uri.TryCreate(url, UriKind.Absolute, out var result)
            ? result
            : throw new ArgumentException("Invalid base URL format - absolute URL is expected", nameof(url));
    }
}
