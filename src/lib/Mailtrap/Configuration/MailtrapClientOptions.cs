// -----------------------------------------------------------------------
// <copyright file="MailtrapClientOptions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Configuration;


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
    /// API Authentication token.
    /// </summary>
    /// 
    /// <remarks>
    /// Required.
    /// </remarks>
    public string ApiToken { get; set; } = string.Empty;

    /// <summary>
    /// Switch to enable JSON indentation for pretty output.
    /// </summary>
    public bool PrettyJson { get; set; } = false;

    /// <summary>
    /// 
    /// </summary>
    public bool UseBulkApi { get; set; } = false;

    /// <summary>
    /// 
    /// </summary>
    public long? InboxId { get; set; } = null;


    /// <summary>
    /// Primary constructor with authentication configuration.
    /// </summary>
    public MailtrapClientOptions(string apiToken)
    {
        Ensure.NotNullOrEmpty(apiToken, nameof(apiToken));

        ApiToken = apiToken;
    }

    /// <summary>
    /// Parameterless instance constructor.
    /// </summary>
    public MailtrapClientOptions() { }



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

        ApiToken = source.ApiToken;
        PrettyJson = source.PrettyJson;
        UseBulkApi = source.UseBulkApi;
        InboxId = source.InboxId;
    }


    /// <summary>
    /// Converts <see cref="MailtrapClientOptions"/> instance to <see cref="JsonSerializerOptions"/>.
    /// </summary>
    internal JsonSerializerOptions ToJsonSerializerOptions()
    {
        return new JsonSerializerOptions(MailtrapJsonSerializerOptions.Default)
        {
            WriteIndented = PrettyJson
        };
    }
}
