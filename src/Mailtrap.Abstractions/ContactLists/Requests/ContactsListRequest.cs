namespace Mailtrap.ContactLists.Requests;

/// <summary>
/// Generic request object for contacts list CRUD operations.
/// </summary>
public record ContactsListRequest : IValidatable
{
    /// <summary>
    /// Gets contacts list name.
    /// </summary>
    ///
    /// <value>
    /// Contacts list name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonRequired]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    ///
    /// <param name="name">
    /// Name of the contacts list.
    /// </param>
    ///
    /// <remarks>
    /// The <paramref name="name"/> must be between 1 and 255 characters.
    /// </remarks>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="name"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public ContactsListRequest(string name)
    {
        Ensure.NotNullOrEmpty(name, nameof(name));

        Name = name;
    }

    /// <summary>
    /// Parameterless instance constructor for serializers.
    /// </summary>
    [JsonConstructor]
    public ContactsListRequest() { }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return ContactsListRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
