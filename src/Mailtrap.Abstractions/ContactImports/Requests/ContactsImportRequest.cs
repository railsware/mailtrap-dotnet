namespace Mailtrap.ContactImports.Requests;

/// <summary>
/// Generic request object for contact CRUD operations.
/// </summary>
public record ContactsImportRequest : IValidatable
{
    /// <summary>
    /// Gets contact collection for import.
    /// </summary>
    ///
    /// <value>
    /// Contact collection for import.
    /// </value>
    [JsonPropertyName("contacts")]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<ContactImportRequest> Contacts { get; } = [];

    /// <summary>
    /// Primary instance constructor.
    /// </summary>
    ///
    /// <param name="contacts">
    /// Collection of contacts to import.
    /// </param>
    ///
    /// <remarks>
    /// Each contact in the <paramref name="contacts"/> collection must have a valid email.
    /// </remarks>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="contacts"/> is <see langword="null"/> or empty.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// When <paramref name="contacts"/> is more than 50000.
    /// </exception>
    public ContactsImportRequest(IEnumerable<ContactImportRequest> contacts)
    {
        Ensure.NotNullOrEmpty(contacts, nameof(contacts));

        // Defensive copy to prevent post-ctor mutation.
        Contacts = contacts is List<ContactImportRequest> list
                        ? new List<ContactImportRequest>(list)
                        : new List<ContactImportRequest>(contacts);
    }

    /// <summary>
    /// Parameterless instance constructor for serializers.
    /// </summary>
    public ContactsImportRequest() { }

    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return ContactsImportRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
