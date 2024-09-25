// -----------------------------------------------------------------------
// <copyright file="MessageDetails.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Message.Models;


/// <summary>
/// Represents details of a message in inbox.
/// </summary>
public sealed record MessageDetails
{
    /// <summary>
    /// Gets message identifier.
    /// </summary>
    ///
    /// <value>
    /// Message identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    public long? Id { get; }

    /// <summary>
    /// Gets message inbox identifier.
    /// </summary>
    ///
    /// <value>
    /// Message inbox identifier.
    /// </value>
    [JsonPropertyName("inbox_id")]
    [JsonPropertyOrder(2)]
    public long? InboxId { get; }

    /// <summary>
    /// Gets message subject.
    /// </summary>
    ///
    /// <value>
    /// Message subject.
    /// </value>
    [JsonPropertyName("subject")]
    [JsonPropertyOrder(3)]
    public string? Subject { get; }

    /// <summary>
    /// Gets email address of 'From' field of the message.
    /// </summary>
    ///
    /// <value>
    /// Email address of 'From' field of the message.
    /// </value>
    [JsonPropertyName("from_email")]
    [JsonPropertyOrder(4)]
    public string? FromEmail { get; }

    /// <summary>
    /// Gets display name of 'From' field of the message.
    /// </summary>
    ///
    /// <value>
    /// Display name of 'From' field of the message.
    /// </value>
    [JsonPropertyName("from_name")]
    [JsonPropertyOrder(5)]
    public string? FromName { get; }

    /// <summary>
    /// Gets email address of 'To' field of the message.
    /// </summary>
    ///
    /// <value>
    /// Email address of 'To' field of the message.
    /// </value>
    [JsonPropertyName("to_email")]
    [JsonPropertyOrder(6)]
    public string? ToEmail { get; }

    /// <summary>
    /// Gets display name of 'To' field of the message.
    /// </summary>
    ///
    /// <value>
    /// Display name of 'To' field of the message.
    /// </value>
    [JsonPropertyName("to_name")]
    [JsonPropertyOrder(7)]
    public string? ToName { get; }

    /// <summary>
    /// Gets size of the message.
    /// </summary>
    ///
    /// <value>
    /// Size of the message.
    /// </value>
    [JsonPropertyName("email_size")]
    [JsonPropertyOrder(8)]
    public long? EmailSize { get; }

    /// <summary>
    /// Gets flag indicating if the message was read.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if the message was read.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("is_read")]
    [JsonPropertyOrder(9)]
    public bool? IsRead { get; }

    /// <summary>
    /// Gets timestamp when the message was created.
    /// </summary>
    ///
    /// <value>
    /// Timestamp when the message was created.
    /// </value>
    [JsonPropertyName("created_at")]
    [JsonPropertyOrder(10)]
    public DateTimeOffset? CreatedAt { get; }

    /// <summary>
    /// Gets timestamp when the message was updated.
    /// </summary>
    ///
    /// <value>
    /// Timestamp when the message was updated.
    /// </value>
    [JsonPropertyName("updated_at")]
    [JsonPropertyOrder(11)]
    public DateTimeOffset? UpdatedAt { get; }

    /// <summary>
    /// Gets timestamp when the message was sent.
    /// </summary>
    ///
    /// <value>
    /// Timestamp when the message was sent.
    /// </value>
    [JsonPropertyName("sent_at")]
    [JsonPropertyOrder(12)]
    public DateTimeOffset? SentAt { get; }

    /// <summary>
    /// Gets HTML body size of the message.
    /// </summary>
    ///
    /// <value>
    /// HTML body size of the message.
    /// </value>
    [JsonPropertyName("html_body_size")]
    [JsonPropertyOrder(13)]
    public long? HtmlBodySize { get; }

    /// <summary>
    /// Gets plain text body size of the message.
    /// </summary>
    ///
    /// <value>
    /// Plain text body size of the message.
    /// </value>
    [JsonPropertyName("text_body_size")]
    [JsonPropertyOrder(14)]
    public long? TextBodySize { get; }

    /// <summary>
    /// Gets human-friendly size of the message.
    /// </summary>
    ///
    /// <value>
    /// Human-friendly size of the message.<br />
    /// E.g. '345 Bytes'.
    /// </value>
    [JsonPropertyName("human_size")]
    [JsonPropertyOrder(15)]
    public string? HumanSize { get; }

    // TODO: Should be URI?
    /// <summary>
    /// Gets path to the HTML representation of the message.
    /// </summary>
    ///
    /// <value>
    /// Path to the HTML representation of the message.
    /// </value>
    [JsonPropertyName("html_path")]
    [JsonPropertyOrder(16)]
    public string? HtmlPath { get; }

    // TODO: Should be URI?
    /// <summary>
    /// Gets path to the plain text representation of the message.
    /// </summary>
    ///
    /// <value>
    /// Path to the plain text representation of the message.
    /// </value>
    [JsonPropertyName("txt_path")]
    [JsonPropertyOrder(17)]
    public string? TextPath { get; }

    // TODO: Should be URI?
    /// <summary>
    /// Gets path to the raw representation of the message.
    /// </summary>
    ///
    /// <value>
    /// Path to the raw representation of the message.
    /// </value>
    [JsonPropertyName("raw_path")]
    [JsonPropertyOrder(18)]
    public string? RawPath { get; }

    // TODO: Should be URI?
    /// <summary>
    /// Gets download path for the message.
    /// </summary>
    ///
    /// <value>
    /// Download path for the message.
    /// </value>
    [JsonPropertyName("download_path")]
    [JsonPropertyOrder(19)]
    public string? DownloadPath { get; }

    // TODO: Should be URI?
    /// <summary>
    /// Gets path to the message HTML source.
    /// </summary>
    ///
    /// <value>
    /// Path to the message HTML source.
    /// </value>
    [JsonPropertyName("html_source_path")]
    [JsonPropertyOrder(20)]
    public string? HtmlSourcePath { get; }

    /// <summary>
    /// Gets flag indicating if the message contains blacklist report.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if the message contains blacklist report.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("blacklists_report_info")]
    [JsonPropertyOrder(21)]
    public bool? HasBlacklistsReportInfo { get; }

    /// <summary>
    /// Gets SMTP information for the message.
    /// </summary>
    ///
    /// <value>
    /// SMTP information for the message.
    /// </value>
    [JsonPropertyName("smtp_information")]
    [JsonPropertyOrder(22)]
    public SmtpInformation SmtpInformation { get; } = new();
}
