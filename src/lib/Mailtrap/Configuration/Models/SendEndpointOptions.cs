// -----------------------------------------------------------------------
// <copyright file="SendEndpointOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


public record SendEndpointOptions : MailtrapApiClientEndpointOptions
{
    public static SendEndpointOptions Default { get; } = new(ApiEndpoints.SendDefaultUrl);

    public SendEndpointOptions(string baseUrl, string? httpClientName = default) : base(baseUrl, httpClientName) { }

    public SendEndpointOptions(Uri baseUrl, string? httpClientName = default) : base(baseUrl, httpClientName) { }
}
