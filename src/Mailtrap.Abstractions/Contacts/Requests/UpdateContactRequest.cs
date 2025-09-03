namespace Mailtrap.Contacts.Requests;

/// <summary>
/// Request object for updating a contact.
/// </summary>
public sealed record UpdateContactRequest : ContactRequest
{
    /// <summary>
    /// Gets contact list IDs to include.
    /// </summary>
    ///
    /// <value>
    /// Contact list IDs to include.
    /// </value>
    [JsonPropertyName("list_ids_included")]
    public IList<int> ListIdsIncluded { get; } = [];

    /// <summary>
    /// Gets contact list IDs to exclude.
    /// </summary>
    ///
    /// <value>
    /// Contact list IDs to exclude.
    /// </value>
    [JsonPropertyName("list_ids_excluded")]
    public IList<int> ListIdsExcluded { get; } = [];

    /// <summary>
    /// Gets contact "unsubscribed" status.
    /// </summary>
    ///
    /// <value>
    /// Contact "unsubscribed" status.
    /// </value>
    [JsonPropertyName("unsubscribed")]
    public bool? Unsubscribed { get; set; }

    /// <inheritdoc />
    public UpdateContactRequest(string email) : base(email) { }
}
