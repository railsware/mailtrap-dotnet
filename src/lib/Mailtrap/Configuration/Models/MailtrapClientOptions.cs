// -----------------------------------------------------------------------
// <copyright file="MailtrapClientOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration.Models;


/// <summary>
/// A set of parameters to configure Mailtrap API client.
/// </summary>
public record MailtrapClientOptions
{
    /// <summary>
    /// Gets default Mailtrap API client configuration.
    /// </summary>
    ///
    /// <value>
    /// Static instance, containing default values for endpoints, serialization and empty authentication settings.
    /// </value>
    public static MailtrapClientOptions Default { get; } = new();

    /// <summary>
    /// Gets or sets endpoint settings for transactional send.
    /// </summary>
    ///
    /// <value>
    /// Options instance, containing endpoint settings for transactional send.
    /// <para>
    /// Defaults to <see cref="MailtrapClientEndpointOptions.SendDefaultEndpointOptions"/>.
    /// </para>
    /// </value>
    public MailtrapClientEndpointOptions SendEndpoint { get; set; } = MailtrapClientEndpointOptions.SendDefaultEndpointOptions;

    /// <summary>
    /// Gets or sets endpoint settings for bulk send.
    /// </summary>
    /// 
    /// <value>
    /// Options instance, containing endpoint settings for bulk send.
    /// <para>
    /// Defaults to <see cref="MailtrapClientEndpointOptions.BulkDefaultEndpointOptions"/>.
    /// </para>
    /// </value>
    public MailtrapClientEndpointOptions BulkEndpoint { get; set; } = MailtrapClientEndpointOptions.BulkDefaultEndpointOptions;


    /// <summary>
    /// Gets or sets endpoint settings for test send.
    /// </summary>
    /// 
    /// <value>
    /// Options instance, containing endpoint settings for test send.
    /// <para>
    /// Defaults to <see cref="MailtrapClientEndpointOptions.TestDefaultEndpointOptions"/>.
    /// </para>
    /// </value>
    public MailtrapClientEndpointOptions TestEndpoint { get; set; } = MailtrapClientEndpointOptions.TestDefaultEndpointOptions;

    /// <summary>
    /// Gets or sets authentication settings.
    /// </summary>
    ///
    /// <value>
    /// Options instance, containing authentication configuration.
    /// <para>
    /// Defaults to <see cref="MailtrapClientAuthenticationOptions.Empty"/>.
    /// </para>
    /// </value>
    public MailtrapClientAuthenticationOptions Authentication { get; set; } = MailtrapClientAuthenticationOptions.Empty;

    /// <summary>
    /// Gets or sets serialization settings.
    /// </summary>
    ///
    /// <value>
    /// Options instance, containing serialization configuration.
    /// <para>
    /// Defaults to <see cref="MailtrapClientSerializationOptions.Default"/>.
    /// </para>
    /// </value>
    public MailtrapClientSerializationOptions Serialization { get; set; } = MailtrapClientSerializationOptions.Default;


    /// <summary>
    /// Instance constructor accepting authentication configuration.
    /// </summary>
    /// 
    /// <param name="authentication">
    /// <see cref="MailtrapClientAuthenticationOptions"/> instance to use.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="authentication"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClientOptions(MailtrapClientAuthenticationOptions authentication)
    {
        Ensure.NotNull(authentication, nameof(authentication));

        Authentication = authentication;
    }

    /// <summary>
    /// Instance constructor accepting API token.
    /// </summary>
    /// 
    /// <param name="apiToken">
    /// API authentication token to use.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="apiToken"/> is <see langword="null"/>.
    /// </exception>
    public MailtrapClientOptions(string apiToken)
        : this(new MailtrapClientAuthenticationOptions(apiToken)) { }

    /// <summary>
    /// Default parameterless instance constructor.
    /// <para>
    /// Defaults authentication settings to <see cref="MailtrapClientAuthenticationOptions.Empty"/>.
    /// </para>
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
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="source"/> is <see langword="null"/>.
    /// </exception>
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
}
