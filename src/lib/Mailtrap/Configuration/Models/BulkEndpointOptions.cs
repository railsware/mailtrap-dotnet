// -----------------------------------------------------------------------
// <copyright file="BulkEndpointOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


public record BulkEndpointOptions : MailtrapApiClientEndpointOptions
{
    public static BulkEndpointOptions Default { get; } = new(ApiEndpoints.BulkDefaultUrl);

    public BulkEndpointOptions(string baseUrl, string? httpClientName = default) : base(baseUrl, httpClientName) { }

    public BulkEndpointOptions(Uri baseUrl, string? httpClientName = default) : base(baseUrl, httpClientName) { }
}
