namespace Mailtrap.ContactImports.Models;

/// <summary>
/// Generic response object for contact imports operations.
/// </summary>
public record ContactsImport
{
    /// <summary>
    /// Gets created contact imports identifier.
    /// </summary>
    ///
    /// <value>
    /// Contact imports identifier.
    /// </value>
    [JsonPropertyName("id")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public long Id { get; set; }

    /// <summary>
    /// Gets contact imports status.
    /// </summary>
    ///
    /// <value>
    /// Contact imports status.
    /// </value>
    [JsonPropertyName("status")]
    [JsonPropertyOrder(2)]
    public ContactsImportStatus? Status { get; set; }

    /// <summary>
    /// Gets count of created contacts.
    /// </summary>
    ///
    /// <value>
    /// Count of created contacts.
    /// </value>
    [JsonPropertyName("created_contacts_count")]
    [JsonPropertyOrder(3)]
    public long? CreatedContactsCount { get; set; }

    /// <summary>
    /// Gets count of updated contacts.
    /// </summary>
    ///
    /// <value>
    /// Count of updated contacts.
    /// </value>
    [JsonPropertyName("updated_contacts_count")]
    [JsonPropertyOrder(4)]
    public long? UpdatedContactsCount { get; set; }

    /// <summary>
    /// Gets count of contacts over limit.
    /// </summary>
    ///
    /// <value>
    /// Count of contacts over limit.
    /// </value>
    [JsonPropertyName("contacts_over_limit_count")]
    [JsonPropertyOrder(5)]
    public long? ContactsOverLimitCount { get; set; }
}
