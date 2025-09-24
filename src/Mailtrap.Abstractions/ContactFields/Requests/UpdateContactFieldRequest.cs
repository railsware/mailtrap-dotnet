namespace Mailtrap.ContactFields.Requests;

/// <summary>
/// Request object for updating a contact field.
/// </summary>
public sealed record UpdateContactFieldRequest : IValidatable
{
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
    /// Gets or sets contact field merge tag.
    /// </summary>
    ///
    /// <value>
    /// Contact field merge tag.
    /// </value>
    [JsonPropertyName("merge_tag")]
    public string? MergeTag { get; set; }

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
    /// <remarks>
    /// <paramref name="name"/> must be 1–80 characters long.<br/>
    /// <paramref name="mergeTag"/> must be 1–80 characters long.
    /// </remarks>
    ///
    /// <exception cref="ArgumentException">
    /// When both <paramref name="name"/> and <paramref name="mergeTag"/> are <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    [JsonConstructor]
    public UpdateContactFieldRequest(string? name, string? mergeTag)
    {
        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(mergeTag))
        {
            throw new ArgumentException($"At least one of {nameof(name)} or {nameof(mergeTag)} must be provided.");
        }

        Name = name;
        MergeTag = mergeTag;
    }

    /// <inheritdoc />
    public ValidationResult Validate()
    {
        return UpdateContactFieldRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
