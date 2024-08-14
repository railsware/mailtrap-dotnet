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
    public MailtrapClientOptions(string apiToken)
        : this(new MailtrapClientAuthenticationOptions(apiToken)) { }

    /// <summary>
    /// Parameterless constructor.
    /// </summary>
    public MailtrapClientOptions()
        : this(MailtrapClientAuthenticationOptions.Empty) { }



    /// <summary>
    /// Initializes current <see cref="MailtrapClientOptions"/> instance with values from <paramref name="source"/>.
    /// </summary>
    /// 
    /// <param name="source">
    /// Source <see cref="MailtrapClientOptions"/> instance to copy values from.
    /// </param>
    /// 
    /// <remarks>
    /// Performs a shallow copy.
    /// </remarks>
    public void Init(MailtrapClientOptions source)
    {
        Ensure.NotNull(source, nameof(source));

        Authentication = source.Authentication;
        Serialization = source.Serialization;
        SendEndpoint = source.SendEndpoint;
        BulkEndpoint = source.BulkEndpoint;
        TestEndpoint = source.TestEndpoint;
    }


    /// <summary>
    /// Gets specific endpoint settings from the configuration.
    /// </summary>
    /// 
    /// <param name="endpoint">
    /// Endpoint, which settings are needed.
    /// </param>
    /// 
    /// <returns>
    /// <see cref="MailtrapClientEndpointOptions"/> for specific endpoint.
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="endpoint"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <exception cref="ArgumentException">
    /// When provided <paramref name="endpoint"/> contains unsupported value.
    /// </exception>
    internal MailtrapClientEndpointOptions GetSendEndpointConfiguration(SendEndpoint endpoint)
    {
        Ensure.NotNull(endpoint, nameof(endpoint));

        return
            endpoint == Email.Models.SendEndpoint.Transactional ? SendEndpoint :
            endpoint == Email.Models.SendEndpoint.Bulk ? BulkEndpoint :
            endpoint == Email.Models.SendEndpoint.Test ? TestEndpoint :
            throw new ArgumentException("Unsupported endpoint type.", nameof(endpoint));
    }
}
