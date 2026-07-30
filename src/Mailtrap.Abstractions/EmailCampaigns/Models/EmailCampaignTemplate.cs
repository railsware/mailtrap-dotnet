namespace Mailtrap.EmailCampaigns.Models;


/// <summary>
/// Represents the template associated with an email campaign.<br/>
/// <see cref="BodyHtml"/> and <see cref="BodyText"/> are returned only on single-campaign
/// responses - the list endpoint omits them to keep the payload small.
/// </summary>
public sealed record EmailCampaignTemplate
{
    /// <summary>
    /// Gets or sets the template identifier.
    /// </summary>
    ///
    /// <value>
    /// Template identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the email subject line.
    /// </summary>
    ///
    /// <value>
    /// Email subject line.
    /// </value>
    [JsonPropertyName("subject")]
    [JsonPropertyOrder(2)]
    public string? Subject { get; set; }

    /// <summary>
    /// Gets the bare names of the merge tags referenced in the subject/body.
    /// </summary>
    ///
    /// <value>
    /// Merge tag names, without the <c>{{ }}</c> delimiters.
    /// </value>
    [JsonPropertyName("merge_tags")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<string> MergeTags { get; } = [];

    /// <summary>
    /// Gets or sets the HTML body of the email (the design).
    /// </summary>
    ///
    /// <value>
    /// HTML body, or <see langword="null"/> when not set or omitted (e.g. in list items).
    /// </value>
    [JsonPropertyName("body_html")]
    [JsonPropertyOrder(4)]
    public string? BodyHtml { get; set; }

    /// <summary>
    /// Gets or sets the plain-text alternative of the email body.
    /// </summary>
    ///
    /// <value>
    /// Plain-text body, or <see langword="null"/> when not set or omitted (e.g. in list items).
    /// </value>
    [JsonPropertyName("body_text")]
    [JsonPropertyOrder(5)]
    public string? BodyText { get; set; }
}
