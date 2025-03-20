namespace Mailtrap.Inboxes.Models;


/// <summary>
/// Represents inbox details.
/// </summary>
public sealed record Inbox
{
    /// <summary>
    /// Gets inbox identifier.
    /// </summary>
    ///
    /// <value>
    /// Inbox identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; set; }

    /// <summary>
    /// Gets inbox name.
    /// </summary>
    ///
    /// <value>
    /// Inbox name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(2)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets inbox user name.
    /// </summary>
    ///
    /// <value>
    /// Inbox user name.
    /// </value>
    [JsonPropertyName("username")]
    [JsonPropertyOrder(3)]
    public string? UserName { get; set; }

    /// <summary>
    /// Gets inbox password.
    /// </summary>
    ///
    /// <value>
    /// Inbox password.
    /// </value>
    [JsonPropertyName("password")]
    [JsonPropertyOrder(4)]
    public string? Password { get; set; }

    /// <summary>
    /// Gets maximum size of the inbox.
    /// </summary>
    ///
    /// <value>
    /// Maximum size of the inbox.
    /// </value>
    [JsonPropertyName("max_size")]
    [JsonPropertyOrder(5)]
    public long? MaxSize { get; set; }

    /// <summary>
    /// Gets inbox status.
    /// </summary>
    ///
    /// <value>
    /// Inbox status.
    /// </value>
    [JsonPropertyName("status")]
    [JsonPropertyOrder(6)]
    public InboxStatus Status { get; set; } = InboxStatus.Unknown;

    /// <summary>
    /// Gets email user name for the inbox.
    /// </summary>
    ///
    /// <value>
    /// Email user name for the inbox.
    /// </value>
    [JsonPropertyName("email_username")]
    [JsonPropertyOrder(7)]
    public string? EmailUsername { get; set; }

    /// <summary>
    /// Gets the flag indicating if email user name is enabled for the inbox.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if email user name is enabled for the inbox.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("email_username_enabled")]
    [JsonPropertyOrder(8)]
    public bool? EmailUsernameEnabled { get; set; }

    /// <summary>
    /// Gets inbox sent messages count.
    /// </summary>
    ///
    /// <value>
    /// Inbox sent messages count.
    /// </value>
    [JsonPropertyName("sent_messages_count")]
    [JsonPropertyOrder(9)]
    public long? SentMessagesCount { get; set; }

    /// <summary>
    /// Gets inbox forwarded messages count.
    /// </summary>
    ///
    /// <value>
    /// Inbox forwarded messages count.
    /// </value>
    [JsonPropertyName("forwarded_messages_count")]
    [JsonPropertyOrder(10)]
    public long? ForwardedMessagesCount { get; set; }

    /// <summary>
    /// Gets the flag indicating if inbox is used.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if the inbox is used.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("used")]
    [JsonPropertyOrder(11)]
    public bool? Used { get; set; }

    /// <summary>
    /// Gets email address used for forwarding.
    /// </summary>
    ///
    /// <value>
    /// Email address used for forwarding.
    /// </value>
    [JsonPropertyName("forward_from_email_address")]
    [JsonPropertyOrder(12)]
    public string? ForwardFromEmailAddress { get; set; }

    /// <summary>
    /// Gets project identifier.
    /// </summary>
    ///
    /// <value>
    /// Project identifier.
    /// </value>
    [JsonPropertyName("project_id")]
    [JsonPropertyOrder(13)]
    [JsonRequired]
    public long ProjectId { get; set; }

    /// <summary>
    /// Gets domain name.
    /// </summary>
    ///
    /// <value>
    /// Domain name.
    /// </value>
    [JsonPropertyName("domain")]
    [JsonPropertyOrder(14)]
    public string? Domain { get; set; }

    /// <summary>
    /// Gets domain name for POP3.
    /// </summary>
    ///
    /// <value>
    /// Domain name for POP3.
    /// </value>
    [JsonPropertyName("pop3_domain")]
    [JsonPropertyOrder(15)]
    public string? Pop3Domain { get; set; }

    /// <summary>
    /// Gets domain name for email.
    /// </summary>
    ///
    /// <value>
    /// Domain name for email.
    /// </value>
    [JsonPropertyName("email_domain")]
    [JsonPropertyOrder(16)]
    public string? EmailDomain { get; set; }

    /// <summary>
    /// Gets emails count.
    /// </summary>
    ///
    /// <value>
    /// Emails count.
    /// </value>
    [JsonPropertyName("emails_count")]
    [JsonPropertyOrder(17)]
    public long? EmailsCount { get; set; }

    /// <summary>
    /// Gets unread emails count.
    /// </summary>
    ///
    /// <value>
    /// Unread emails count.
    /// </value>
    [JsonPropertyName("emails_unread_count")]
    [JsonPropertyOrder(18)]
    public long? UnreadEmailsCount { get; set; }

    /// <summary>
    /// Gets the timestamp when the last message was sent.
    /// </summary>
    ///
    /// <value>
    /// Timestamp when the last message was sent.
    /// </value>
    [JsonPropertyName("last_message_sent_at")]
    [JsonPropertyOrder(19)]
    public DateTimeOffset? LastMessageSentAt { get; set; }

    /// <summary>
    /// Gets a list of SMTP ports.
    /// </summary>
    ///
    /// <value>
    /// List of SMTP ports.
    /// </value>
    [JsonPropertyName("smtp_ports")]
    [JsonPropertyOrder(20)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<int> SmtpPorts { get; } = [];

    /// <summary>
    /// Gets a list of POP3 ports.
    /// </summary>
    ///
    /// <value>
    /// List of POP3 ports.
    /// </value>
    [JsonPropertyName("pop3_ports")]
    [JsonPropertyOrder(21)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<int> Pop3Ports { get; } = [];

    /// <summary>
    /// Gets maximum message size.
    /// </summary>
    ///
    /// <value>
    /// Maximum message size.
    /// </value>
    [JsonPropertyName("max_message_size")]
    [JsonPropertyOrder(22)]
    public long? MaxMessageSize { get; set; }

    /// <summary>
    /// Gets permissions for this inbox granted for the current token.
    /// </summary>
    ///
    /// <value>
    /// Permissions for this inbox granted for the current token.
    /// </value>
    [JsonPropertyName("permissions")]
    [JsonPropertyOrder(23)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public InboxPermissions Permissions { get; } = new();
}
