// -----------------------------------------------------------------------
// <copyright file="MailtrapApiClientOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// A set of options to configure Mailtrap API client.
/// </summary>
public record MailtrapApiClientOptions
{
    /// <summary>
    /// Default configuration.
    /// <para>
    /// Includes default values for endpoints, serialization and empty authentication settings.
    /// </para>
    /// </summary>
    public static MailtrapApiClientOptions Default { get; } = new();

    /// <summary>
    /// Send email endpoint settings
    /// </summary>
    public MailtrapApiClientEndpointOptions SendEndpoint { get; set; } = new MailtrapApiClientEndpointOptions(ApiEndpoints.SendDefaultUrl);

    /// <summary>
    /// Test email endpoint settings
    /// </summary>
    public MailtrapApiClientEndpointOptions TestEndpoint { get; set; } = new MailtrapApiClientEndpointOptions(ApiEndpoints.TestDefaultUrl);

    /// <summary>
    /// Bulk email endpoint settings
    /// </summary>
    public MailtrapApiClientEndpointOptions BulkEndpoint { get; set; } = new MailtrapApiClientEndpointOptions(ApiEndpoints.BulkDefaultUrl);

    /// <summary>
    /// API authentication settings
    /// </summary>
    public MailtrapApiClientAuthenticationOptions Authentication { get; set; } = MailtrapApiClientAuthenticationOptions.Empty;

    /// <summary>
    /// Serialization settings
    /// </summary>
    public MailtrapApiClientSerializationOptions Serialization { get; set; } = MailtrapApiClientSerializationOptions.Default;
}
