// -----------------------------------------------------------------------
// <copyright file="Attachment.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Models;


/// <summary>
/// Record containing email attachment details
/// </summary>
public record Attachment
{
    /// <summary>
    /// The Base64 encoded content of the attachment.
    /// </summary>
    /// <remarks>
    /// Required, non-empty string.
    /// </remarks>
    [JsonPropertyName("content")]
    public string Content { get; }

    /// <summary>
    /// Attachment file name.
    /// </summary>
    /// <remarks>
    /// Required.
    /// </remarks>
    [JsonPropertyName("filename")]
    public string FileName { get; }

    /// <summary>
    /// Attachment MIME type identifier (e.g. "text/plain", "application/pdf", etc.)
    /// </summary>
    /// <remarks>
    /// Optional.
    /// </remarks>
    [JsonPropertyName("type")]
    public string? MimeType { get; }

    /// <summary>
    /// The attachment's content-disposition, specifying how you would like the attachment to be displayed.
    /// <para>
    /// For example, <see cref="DispositionType.Inline"/> results in the attached file are displayed automatically within the message, 
    /// while <see cref="DispositionType.Attachment"/> results in the attached file require some action to be taken before it is displayed,
    /// such as opening or downloading the file.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Optional. Defaults to <see cref="DispositionType.Attachment"/> if not specified explicitly.
    /// </remarks>
    [JsonPropertyName("disposition")]
    public DispositionType Disposition { get; }

    /// <summary>
    /// The attachment's content ID.<br />
    /// This is used when the disposition is set to <see cref="DispositionType.Inline"/> and the attachment is an image,
    /// allowing the file to be displayed within the body of your email.
    /// </summary>
    /// <remarks>
    /// Optional.
    /// </remarks>
    [JsonPropertyName("content_id")]
    public string? ContentId { get; }


    /// <summary>
    /// Constructor for <see cref="Attachment"/> instance
    /// </summary>
    /// <param name="content">Required. Base64 encoded string with attachment content. Should contain at least 1 char.</param>
    /// <param name="filename">Required. Filename of the attachment. Empty string is allowed.</param>
    /// <param name="dispositionType">Optional. Attachment's disposition type. Defaults to <see cref="DispositionType.Attachment"/> when not specified.</param>
    /// <param name="mimeType">Optional. MIME type of the attachement.</param>
    /// <param name="contentId">Optional. Attachment's content ID.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public Attachment(string content, string filename, DispositionType? dispositionType = null, string? mimeType = null, string? contentId = null)
    {
        Ensure.NotNullOrEmpty(content, nameof(content));
        Ensure.NotNull(filename, nameof(filename));

        Content = content;
        FileName = filename;
        Disposition = dispositionType ?? DispositionType.Attachment;
        MimeType = mimeType;
        ContentId = contentId;
    }
}
