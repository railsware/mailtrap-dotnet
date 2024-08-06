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
    ///
    /// <remarks>
    /// Returns new object every time, thus it's safe to mutate returned value.
    /// </remarks>
    public static MailtrapClientOptions Default => new();

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
    public MailtrapClientOptions(string apiToken)
    {
        Ensure.NotNullOrEmpty(apiToken, nameof(apiToken));

        Authentication.ApiToken = apiToken;
    }

    /// <summary>
    /// Parameterless instance constructor.
    /// </summary>
    public MailtrapClientOptions() { }



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
