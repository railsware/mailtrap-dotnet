// -----------------------------------------------------------------------
// <copyright file="MailtrapClientOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// A set of options to configure Mailtrap API client.
/// </summary>
public record MailtrapClientOptions
{
    /// <summary>
    /// Default configuration.
    /// <para>
    /// Includes default values for endpoints, serialization and empty authentication settings.
    /// </para>
    /// </summary>
    public static MailtrapClientOptions Default { get; } = new();

    /// <summary>
    /// Send email endpoint settings
    /// </summary>
    public MailtrapClientEndpointOptions SendEndpoint { get; set; } = MailtrapClientEndpointOptions.SendDefault;

    /// <summary>
    /// Test email endpoint settings
    /// </summary>
    public MailtrapClientEndpointOptions TestEndpoint { get; set; } = MailtrapClientEndpointOptions.TestDefault;

    /// <summary>
    /// Bulk email endpoint settings
    /// </summary>
    public MailtrapClientEndpointOptions BulkEndpoint { get; set; } = MailtrapClientEndpointOptions.BulkDefault;

    /// <summary>
    /// API authentication settings
    /// </summary>
    public MailtrapClientAuthenticationOptions Authentication { get; set; } = MailtrapClientAuthenticationOptions.Empty;

    /// <summary>
    /// Serialization settings
    /// </summary>
    public MailtrapClientSerializationOptions Serialization { get; set; } = MailtrapClientSerializationOptions.Default;
}
