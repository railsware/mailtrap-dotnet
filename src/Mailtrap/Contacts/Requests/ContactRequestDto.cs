namespace Mailtrap.Contacts.Requests;


/// <summary>
/// Generic request object for contact CRUD operations.
/// </summary>
internal record ContactRequestDto<T> : IValidatable
    where T : ContactRequest
{
    /// <summary>
    /// Gets contact request payload.
    /// </summary>
    ///
    /// <value>
    /// Contact request payload.
    /// </value>
    [JsonPropertyName("contact")]
    [JsonPropertyOrder(1)]
    public T Contact { get; }


    public ContactRequestDto(T contact)
    {
        Ensure.NotNull(contact, nameof(contact));

        Contact = contact;
    }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return ContactRequestValidator.Instance
            .Validate(Contact)
            .ToMailtrapValidationResult();
    }
}
