namespace Mailtrap.ContactFields.Models;

/// <summary>
/// Represents Contact Field details.
/// </summary>
public sealed record ContactField
{
    /// <summary>
    /// Gets or sets contact field identifier.
    /// </summary>
    ///
    /// <value>
    /// Contact field identifier.
    /// </value>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets contact field name.
    /// </summary>
    ///
    /// <value>
    /// Contact field name.
    /// </value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets contact field data type.
    /// </summary>
    ///
    /// <value>
    /// Contact field data type.
    /// </value>
    [JsonPropertyName("data_type")]
    public ContactFieldDataType? DataType { get; set; }

    /// <summary>
    /// Gets or sets contact field merge tag.
    /// </summary>
    ///
    /// <value>
    /// Contact field merge tag.
    /// </value>
    [JsonPropertyName("merge_tag")]
    public string? MergeTag { get; set; }
}
