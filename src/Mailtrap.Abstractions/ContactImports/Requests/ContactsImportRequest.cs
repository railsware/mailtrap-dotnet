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
    /// /// <remarks>
    /// Each contact in the <paramref name="contacts"/> must include a valid email.
    /// Size and item-level constraints are validated by <see cref="Validate"/>.
    /// </remarks>
    ///
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="contacts"/> is <see langword="null"/> or empty.
    /// </exception>
    /// <para>
    /// Use <see cref="Validate"/> to ensure the count is within the allowed range
    /// (currently 1–50,000) and each contact satisfies per-item rules.
    /// </para>
    public ContactsImportRequest(IEnumerable<ContactImportRequest> contacts)
    {
        Ensure.NotNullOrEmpty(contacts, nameof(contacts));

        // Defensive copy to prevent post-ctor mutation.
        Contacts = contacts is List<ContactImportRequest> list
                        ? new List<ContactImportRequest>(list)       // defensive copy when already a List<T>
                        : new List<ContactImportRequest>(contacts);  // otherwise enumerate once
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
