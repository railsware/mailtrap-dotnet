// -----------------------------------------------------------------------
// <copyright file="Attachment.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Models;


/// <summary>
/// Represents email attachment.
/// </summary>
public record Attachment
{
    /// <summary>
    /// Gets the Base64 encoded content of the attachment.
    /// <para>
    /// Required. Must be non-empty string.
    /// </para>
    /// </summary>
    ///
    /// <value>
    /// Contains Base64 encoded content of the attachment.
    /// </value>
    [JsonPropertyName("content")]
    [JsonPropertyOrder(1)]
    public string Content { get; }

    /// <summary>
    /// Gets attachment's file name.
    /// <para>
    /// Required. Must be non-empty string.
    /// </para>
    /// </summary>
    ///
    /// <value>
    /// Contains attachment file name.
    /// </value>
    [JsonPropertyName("filename")]
    [JsonPropertyOrder(2)]
    public string FileName { get; }

    /// <summary>
    /// Gets the attachment's content disposition, specifying how the attachment will be displayed.
    /// <para>
    /// Optional.
    /// </para>
    /// </summary>
    ///
    /// <value>
    /// Indicates attachment's content disposition.
    /// <para>
    /// <see cref="DispositionType.Inline"/> results in the attached file are displayed automatically within the message.<br/>
    /// <see cref="DispositionType.Attachment"/> results in the attached file require some action to be taken before it is displayed,
    /// such as opening or downloading the file.
    /// </para>
    /// <para>
    /// Defaults to <see cref="DispositionType.Attachment"/>, if not specified explicitly.
    /// </para>
    /// </value>
    [JsonPropertyName("disposition")]
    [JsonPropertyOrder(3)]
    public DispositionType Disposition { get; }

    /// <summary>
    /// Gets the attachment's MIME type identifier.
    /// <para>
    /// Optional.
    /// </para>
    /// </summary>
    /// 
    /// <value>
    /// Contains the attachment's MIME type identifier.<br/>
    /// E.g. "text/plain", "application/pdf", etc.
    /// </value>
    [JsonPropertyName("type")]
    [JsonPropertyOrder(4)]
    public string? MimeType { get; }

    /// <summary>
    /// Gets the attachment's content ID.
    /// <para>
    /// Optional.
    /// </para>
    /// </summary>
    ///
    /// <value>
    /// Contains the attachment's content ID.
    /// </value>
    /// 
    /// <remarks>
    /// This is used when the disposition is set to <see cref="DispositionType.Inline"/> and the attachment is an image,
    /// allowing the file to be displayed within the body of your email.
    /// </remarks>
    [JsonPropertyName("content_id")]
    [JsonPropertyOrder(5)]
    public string? ContentId { get; }


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="content">
    /// <para>
    /// The Base64 encoded content of the attachment.
    /// </para>
    /// <para>
    /// Required. Must be non-empty string.
    /// </para>
    /// </param>
    /// 
    /// <param name="fileName">
    /// <para>
    /// Attachment file name.
    /// </para>
    /// <para>
    /// Required. Must be non-empty string.
    /// </para>
    /// </param>
    /// 
    /// <param name="disposition">
    /// <para>
    /// The attachment's content disposition, specifying how you would like the attachment to be displayed.
    /// </para>
    /// <para>
    /// Optional. Defaults to <see cref="DispositionType.Attachment"/> if not specified explicitly.
    /// </para>
    /// </param>
    /// 
    /// <param name="mimeType">
    /// <para>
    /// Attachment MIME type identifier (e.g. "text/plain", "application/pdf", etc.)
    /// </para>
    /// <para>
    /// Optional.
    /// </para>
    /// </param>
    /// 
    /// <param name="contentId">
    /// <para>
    /// The attachment's content ID.
    /// </para>
    /// <para>
    /// Optional.
    /// </para>
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="content"/> is <see langword="null"/> or <see cref="string.Empty"/>.<br />
    /// When <paramref name="fileName"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public Attachment(
        string content,
        string fileName,
        DispositionType? disposition = default,
        string? mimeType = default,
        string? contentId = default)
    {
        Ensure.NotNullOrEmpty(content, nameof(content));
        Ensure.NotNullOrEmpty(fileName, nameof(fileName));

        Content = content;
        FileName = fileName;
        Disposition = disposition ?? DispositionType.Attachment;
        MimeType = mimeType;
        ContentId = contentId;
    }
}
