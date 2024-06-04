// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Options.Models;


public record BulkEndpointOptions : MailtrapApiClientEndpointOptions
{
    public static BulkEndpointOptions Default { get; } = new("https://bulk.api.mailtrap.io/");

    public BulkEndpointOptions(string baseUrl) : base(baseUrl) { }

    public BulkEndpointOptions(Uri baseUrl) : base(baseUrl) { }
}
