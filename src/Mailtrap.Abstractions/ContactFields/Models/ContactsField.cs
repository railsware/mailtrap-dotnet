namespace Mailtrap.ContactFields.Models;

/// <summary>
/// Represents Contacts Field details.
/// </summary>
public sealed record ContactsField
{
    /// <summary>
    /// Gets Contacts field identifier.
    /// </summary>
    ///
    /// <value>
    /// Contacts field identifier.
    /// </value>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets Contacts field name.
    /// </summary>
    ///
    /// <value>
    /// Contacts field name.
    /// </value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets Contacts field data type.
    /// </summary>
    ///
    /// <value>
    /// Contacts field data type.
    /// </value>
    [JsonPropertyName("data_type")]
    public ContactsFieldDataType? DataType { get; set; }

    /// <summary>
    /// Gets Contacts field merge tag.
    /// </summary>
    ///
    /// <value>
    /// Contacts field merge tag.
    /// </value>
    [JsonPropertyName("merge_tag")]
    public string? MergeTag { get; set; }
}
