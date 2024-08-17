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
    ///
    /// <remarks>
    /// Returns new object every time, thus it's safe to mutate returned value.
    /// </remarks>
    public static MailtrapClientSerializationOptions Default => new();

    /// <summary>
    /// Switch to enable JSON indentation for pretty output.
    /// </summary>
    public bool PrettyJson { get; set; } = false;


    /// <summary>
    /// Converts <see cref="MailtrapClientSerializationOptions"/> instance to <see cref="JsonSerializerOptions"/>.
    /// </summary>
    internal JsonSerializerOptions ToJsonSerializerOptions()
    {
        return new JsonSerializerOptions(MailtrapJsonSerializerOptions.Default)
        {
            WriteIndented = PrettyJson
        };
    }
}
