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
    [JsonRequired]
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
    public ContactsImportRequest(IReadOnlyList<ContactImportRequest> contacts)
    {
        Ensure.NotNullOrEmpty(contacts, nameof(contacts));
        Ensure.RangeCondition(contacts.Count <= ContactsImportRequestValidator.MaxContactsPerRequest, nameof(contacts));

        // Defensive copy to prevent post-ctor mutation.
        Contacts = contacts is List<ContactImportRequest> list
                        ? new List<ContactImportRequest>(list)
                        : new List<ContactImportRequest>(contacts);
    }

    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return ContactsImportRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
