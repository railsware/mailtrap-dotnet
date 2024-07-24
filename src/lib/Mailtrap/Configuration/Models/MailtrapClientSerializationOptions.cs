// -----------------------------------------------------------------------
// <copyright file="MailtrapClientSerializationOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// A set of parameters to configure serialization settings for Mailtrap API client.
/// </summary>
public record MailtrapClientSerializationOptions
{
    /// <summary>
    /// Gets default serialization settings.
    /// </summary>
    ///
    /// <value>
    /// Static instance, containing default serialization configuration.
    /// </value>
    public static MailtrapClientSerializationOptions Default { get; } = new();

    /// <summary>
    /// Gets of sets flag which controls JSON indentation for pretty or minified output.
    /// </summary>
    ///
    /// <value>
    /// <see langword="false"/> when JSON should be minified.<br/>
    /// <see langword="true"/> when JSON should be indented.
    /// <para>
    /// Default is <see langword="false"/>.
    /// </para>
    /// </value>
    public bool PrettyJson { get; set; } = false;
}
