// -----------------------------------------------------------------------
// <copyright file="TestEndpointOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


public record TestEndpointOptions : MailtrapApiClientEndpointOptions
{
    public static TestEndpointOptions Default { get; } = new(ApiEndpoints.TestDefaultUrl);

    public TestEndpointOptions(string baseUrl, string? httpClientName = default) : base(baseUrl, httpClientName) { }

    public TestEndpointOptions(Uri baseUrl, string? httpClientName = default) : base(baseUrl, httpClientName) { }
}
