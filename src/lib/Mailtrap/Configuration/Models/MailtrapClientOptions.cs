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
    /// Send email endpoint settings.
    /// </summary>
    public MailtrapClientEndpointOptions SendEndpoint { get; set; } = MailtrapClientEndpointOptions.SendDefault;

    /// <summary>
    /// Test email endpoint settings.
    /// </summary>
    public MailtrapClientEndpointOptions TestEndpoint { get; set; } = MailtrapClientEndpointOptions.TestDefault;

    /// <summary>
    /// Bulk email endpoint settings.
    /// </summary>
    public MailtrapClientEndpointOptions BulkEndpoint { get; set; } = MailtrapClientEndpointOptions.BulkDefault;

    /// <summary>
    /// Authentication settings.
    /// </summary>
    public MailtrapClientAuthenticationOptions Authentication { get; set; } = MailtrapClientAuthenticationOptions.Empty;

    /// <summary>
    /// Serialization settings.
    /// </summary>
    public MailtrapClientSerializationOptions Serialization { get; set; } = MailtrapClientSerializationOptions.Default;


    /// <summary>
    /// Primary constructor with authentication configuration.
    /// </summary>
    public MailtrapClientOptions(MailtrapClientAuthenticationOptions authentication)
    {
        Ensure.NotNull(authentication, nameof(authentication));

        Authentication = authentication;
    }

    /// <summary>
    /// Primary constructor with authentication configuration.
    /// </summary>
    public MailtrapClientOptions(string apiKey)
        : this(new MailtrapClientAuthenticationOptions(apiKey)) { }

    /// <summary>
    /// Parameterles constructor.
    /// </summary>
    public MailtrapClientOptions()
        : this(MailtrapClientAuthenticationOptions.Empty) { }



    /// <summary>
    /// Initializes current <see cref="MailtrapClientOptions"/> instance with values from <paramref name="source"/>.
    /// </summary>
    /// <remarks>
    /// Performs a shallow copy.
    /// </remarks>
    /// <param name="source">Source <see cref="MailtrapClientOptions"/> instance to copy values from.</param>
    public void Init(MailtrapClientOptions source)
    {
        Ensure.NotNull(source, nameof(source));

        Authentication = source.Authentication;
        Serialization = source.Serialization;
        SendEndpoint = source.SendEndpoint;
        BulkEndpoint = source.BulkEndpoint;
        TestEndpoint = source.TestEndpoint;
    }
}
