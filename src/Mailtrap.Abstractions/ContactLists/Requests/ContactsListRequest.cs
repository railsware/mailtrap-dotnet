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
    /// Contacts List's <paramref name="name"/> must be min 1 characters and max 255 characters long.
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
    public ContactsListRequest() { }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return ContactsListRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
