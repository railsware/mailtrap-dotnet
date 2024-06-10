// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientSerializationOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


public record MailtrapApiClientSerializationOptions
{
    public static MailtrapApiClientSerializationOptions Default { get; } = new();

    public bool PrettyJson { get; set; } = false;
}
