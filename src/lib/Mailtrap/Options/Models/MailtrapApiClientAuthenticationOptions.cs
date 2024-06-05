// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientAuthenticationOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Options.Models;


public record MailtrapApiClientAuthenticationOptions
{
    public static MailtrapApiClientAuthenticationOptions Default { get; } = new();

    public string ApiToken { get; set; } = string.Empty;
}
