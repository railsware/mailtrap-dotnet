// -----------------------------------------------------------------------
// <copyright file="MailtrapClientSerializationOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// A set of options to configure serialization settings for Mailtrap API client.
/// </summary>
public record MailtrapClientSerializationOptions
{
    /// <summary>
    /// Default set of settings
    /// </summary>
    public static MailtrapClientSerializationOptions Default { get; } = new();

    /// <summary>
    /// Switch to enable JSON indentation for pretty output.
    /// </summary>
    public bool PrettyJson { get; set; } = false;
}
