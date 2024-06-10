// -----------------------------------------------------------------------
// <copyright file="Attachment.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Models;


/// <summary>
/// Email attachment details
/// </summary>
public record Attachment
{
    /// <summary>
    /// Base64 encoded attachment content
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Attachment file name
    /// </summary>
    public string Filename { get; }

    /// <summary>
    /// Attachment MIME type identifier
    /// </summary>
    [JsonPropertyName("type")]
    public string? MimeType { get; }

    /// <summary>
    /// Attachment disposition
    /// </summary>
    public DispositionType Disposition { get; }


    /// <summary>
    /// Constructor for <see cref="Attachment"/> instance
    /// </summary>
    /// <param name="content">Required. Base64 encoded string with attachment content. Should contain at least 1 char.</param>
    /// <param name="filename">Required. Filename of the attachment. Empty string is allowed.</param>
    /// <param name="dispositionType">Optional. Defaults to <see cref="DispositionType.Attachment"/> when not specified.</param>
    /// <param name="mimeType">Optional</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public Attachment(string content, string filename, DispositionType? dispositionType = null, string? mimeType = null)
    {
        Ensure.NotNullOrEmpty(content, nameof(content));
        Ensure.NotNull(filename, nameof(filename));

        Content = content;
        Filename = filename;
        Disposition = dispositionType ?? DispositionType.Attachment;
        MimeType = mimeType;
    }
}
