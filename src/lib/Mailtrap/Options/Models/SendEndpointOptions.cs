// -----------------------------------------------------------------------
// <copyright file="SendEndpointOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Options.Models;


public record SendEndpointOptions : MailtrapApiClientEndpointOptions
{
    public static SendEndpointOptions Default { get; } = new("https://send.api.mailtrap.io/");

    public SendEndpointOptions(string baseUrl) : base(baseUrl) { }

    public SendEndpointOptions(Uri baseUrl) : base(baseUrl) { }
}
