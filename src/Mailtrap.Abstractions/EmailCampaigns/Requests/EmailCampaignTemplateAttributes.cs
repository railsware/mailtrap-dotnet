namespace Mailtrap.EmailCampaigns.Requests;


/// <summary>
/// Represents the template attributes of an email campaign create/update request -
/// the campaign's subject and design.<br/>
/// The campaign's template is always edited in place and updates are partial:
/// only the sub-fields you provide change; omitted sub-fields keep their current value.
/// </summary>
public sealed record EmailCampaignTemplateAttributes
{
    /// <summary>
    /// Gets or sets the email subject line.<br/>
    /// Required when creating a campaign. Supports merge tags, e.g. <c>Hi {{first_name}}</c>.
    /// </summary>
    ///
    /// <value>
    /// Email subject line, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("subject")]
    [JsonPropertyOrder(1)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Subject { get; set; }

    /// <summary>
    /// Gets or sets the HTML body of the email (the design).<br/>
    /// Optional for a draft; required before the campaign can be scheduled or started.
    /// Include an unsubscribe link via an anchor whose <c>href</c> contains the
    /// <c>__unsubscribe_url__</c> placeholder. Supports <c>{{tag_name}}</c> merge tags.
    /// </summary>
    ///
    /// <value>
    /// HTML body, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("body_html")]
    [JsonPropertyOrder(2)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BodyHtml { get; set; }

    /// <summary>
    /// Gets or sets the plain-text alternative of the email body.<br/>
    /// Supports the same <c>__unsubscribe_url__</c> placeholder and <c>{{tag_name}}</c>
    /// merge tags as <see cref="BodyHtml"/>.
    /// </summary>
    ///
    /// <value>
    /// Plain-text body, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("body_text")]
    [JsonPropertyOrder(3)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BodyText { get; set; }

    /// <summary>
    /// Gets or sets the bare names of the merge tags referenced in the subject/body,
    /// without the <c>{{ }}</c> delimiters - e.g. <c>["first_name"]</c> when the content
    /// contains <c>{{first_name}}</c>.<br/>
    /// Replaced as a whole when provided.
    /// </summary>
    ///
    /// <value>
    /// Merge tag names, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("merge_tags")]
    [JsonPropertyOrder(4)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<string>? MergeTags { get; set; }
}
