namespace Mailtrap.Contacts.Requests;

/// <summary>
/// Request object for importing a contact.
/// </summary>
public record ContactImportRequest : ContactRequest
{
    /// <summary>
    /// Gets contact list IDs to include.
    /// </summary>
    ///
    /// <value>
    /// Contact list IDs to include.
    /// </value>
    [JsonPropertyName("list_ids_included")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<int> ListIdsIncluded { get; } = [];

    /// <summary>
    /// Gets contact list IDs to exclude.
    /// </summary>
    ///
    /// <value>
    /// Contact list IDs to exclude.
    /// </value>
    [JsonPropertyName("list_ids_excluded")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<int> ListIdsExcluded { get; } = [];

    /// <inheritdoc />
    public ContactImportRequest(string email) : base(email) { }

    /// <summary>
    /// Parameterless instance constructor for serializers.
    /// </summary>
    public ContactImportRequest() { }
}
