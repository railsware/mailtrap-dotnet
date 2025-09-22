namespace Mailtrap.ContactFields.Requests;

/// <summary>
/// Request object for updating a contacts field.
/// </summary>
public sealed record UpdateContactsFieldRequest : IValidatable
{
    /// <summary>
    /// Gets or sets contacts field name.
    /// </summary>
    ///
    /// <value>
    /// Contacts field name.
    /// </value>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets Contacts field merge tag.
    /// </summary>
    ///
    /// <value>
    /// Contacts field merge tag.
    /// </value>
    [JsonPropertyName("merge_tag")]
    public string? MergeTag { get; set; }

    /// <inheritdoc />
    [JsonConstructor]
    public UpdateContactsFieldRequest(string? name, string? mergeTag)
    {
        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(mergeTag))
        {
            throw new ArgumentNullException(nameof(name), $"At least one of {nameof(name)} or {nameof(mergeTag)} must be provided.");
        }

        Name = name;
        MergeTag = mergeTag;
    }

    /// <inheritdoc />
    public ValidationResult Validate()
    {
        return UpdateContactsFieldRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
