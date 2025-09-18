namespace Mailtrap.ContactFields.Requests;

/// <summary>
/// Request object for creating a contacts field.
/// </summary>
public sealed record CreateContactsFieldRequest : IValidatable
{
    /// <summary>
    /// Gets contacts field name.
    /// </summary>
    ///
    /// <value>
    /// Contacts field name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonRequired]
    public string Name { get; set; }

    /// <summary>
    /// Gets Contacts field merge tag.
    /// </summary>
    ///
    /// <value>
    /// Contacts field merge tag.
    /// </value>
    [JsonPropertyName("merge_tag")]
    [JsonRequired]
    public string MergeTag { get; set; }

    /// <summary>
    /// Gets Contacts field data type.
    /// </summary>
    ///
    /// <value>
    /// Contacts field data type.
    /// </value>

    [JsonPropertyName("data_type")]
    [JsonRequired]
    public ContactsFieldDataType? DataType { get; set; }

    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    ///
    /// <param name="name">
    /// Name of the contact.
    /// </param>
    ///
    /// <param name="mergeTag">
    /// Contacts field merge tag.
    /// </param>
    ///
    /// <param name="dataType">
    /// Contacts field data type.
    /// </param>
    ///
    /// <remarks>
    /// Contacts field's <paramref name="name"/> must be min 1 characters and max 80 characters long.<br/>
    /// Contacts field's <paramref name="mergeTag"/> must be min 1 characters and max 80 characters long.
    /// </remarks>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="name"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// When <paramref name="mergeTag"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    [JsonConstructor]
    public CreateContactsFieldRequest(string name, string mergeTag, ContactsFieldDataType dataType)
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
        return CreateContactsFieldRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
