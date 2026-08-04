namespace Mailtrap.Inbound.Models;


/// <summary>
/// Represents attachment metadata on a received message.<br/>
/// <see cref="DownloadUrl"/> and <see cref="DownloadUrlExpiresAt"/> are populated
/// only on get-by-id and thread responses.
/// </summary>
public sealed record InboundAttachment
{
    /// <summary>
    /// Gets or sets the attachment identifier.
    /// </summary>
    ///
    /// <value>
    /// Attachment identifier.
    /// </value>
    [JsonPropertyName("attachment_id")]
    public string? AttachmentId { get; set; }

    /// <summary>
    /// Gets or sets the attachment size, in bytes.
    /// </summary>
    ///
    /// <value>
    /// Attachment size, in bytes.
    /// </value>
    [JsonPropertyName("size")]
    public int? Size { get; set; }

    /// <summary>
    /// Gets or sets the attachment file name.
    /// </summary>
    ///
    /// <value>
    /// Attachment file name.
    /// </value>
    [JsonPropertyName("filename")]
    public string? FileName { get; set; }

    /// <summary>
    /// Gets or sets the MIME type of the attachment.
    /// </summary>
    ///
    /// <value>
    /// MIME type of the attachment.
    /// </value>
    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

    /// <summary>
    /// Gets or sets the content disposition of the attachment.
    /// </summary>
    ///
    /// <value>
    /// Content disposition of the attachment.
    /// </value>
    [JsonPropertyName("content_disposition")]
    public string? ContentDisposition { get; set; }

    /// <summary>
    /// Gets or sets the content identifier of the attachment.
    /// </summary>
    ///
    /// <value>
    /// Content identifier of the attachment.
    /// </value>
    [JsonPropertyName("content_id")]
    public string? ContentId { get; set; }

    /// <summary>
    /// Gets or sets the signed URL to download the attachment.
    /// </summary>
    ///
    /// <value>
    /// Signed download URL.
    /// </value>
    [JsonPropertyName("download_url")]
    public string? DownloadUrl { get; set; }

    /// <summary>
    /// Gets or sets the expiration timestamp of the signed download URL.
    /// </summary>
    ///
    /// <value>
    /// Expiration timestamp of the signed download URL.
    /// </value>
    [JsonPropertyName("download_url_expires_at")]
    public DateTimeOffset? DownloadUrlExpiresAt { get; set; }
}
