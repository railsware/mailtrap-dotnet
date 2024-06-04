// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Options.Models;


public record TestEndpointOptions : MailtrapApiClientEndpointOptions
{
    public static TestEndpointOptions Default { get; } = new("https://test.api.mailtrap.io/");

    public TestEndpointOptions(string baseUrl) : base(baseUrl) { }

    public TestEndpointOptions(Uri baseUrl) : base(baseUrl) { }
}
