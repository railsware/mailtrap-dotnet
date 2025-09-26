namespace Mailtrap.ContactFields.Requests;

/// <summary>
/// Request object for creating a contact field.
/// </summary>
public sealed record CreateContactFieldRequest : IValidatable
{
    /// <summary>
    /// Gets or sets contact field name.
    /// </summary>
    ///
    /// <value>
    /// Contact field name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonRequired]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets contact field merge tag.
    /// </summary>
    ///
    /// <value>
    /// Contact field merge tag.
    /// </value>
    [JsonPropertyName("merge_tag")]
    [JsonRequired]
    public string MergeTag { get; set; }

    /// <summary>
    /// Gets or sets contact field data type.
    /// </summary>
    ///
    /// <value>
    /// Contact field data type.
    /// </value>

    [JsonPropertyName("data_type")]
    [JsonRequired]
    public ContactFieldDataType DataType { get; set; }

    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    ///
    /// <param name="name">
    /// Contact field name.
    /// </param>
    ///
    /// <param name="mergeTag">
    /// Contact field merge tag.
    /// </param>
    ///
    /// <param name="dataType">
    /// Contact field data type.
    /// </param>
    ///
    /// <remarks>
    /// <paramref name="name"/> must be 1–80 characters long.<br/>
    /// <paramref name="mergeTag"/> must be 1–80 characters long.
    /// </remarks>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="name"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// When <paramref name="mergeTag"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    [JsonConstructor]
    public CreateContactFieldRequest(string name, string mergeTag, ContactFieldDataType dataType)
    {
        Ensure.NotNullOrEmpty(name, nameof(name));
        Ensure.NotNullOrEmpty(mergeTag, nameof(mergeTag));

        Name = name;
        MergeTag = mergeTag;
        DataType = dataType;

    }

    /// <inheritdoc />
    public ValidationResult Validate()
    {
        return CreateContactFieldRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
