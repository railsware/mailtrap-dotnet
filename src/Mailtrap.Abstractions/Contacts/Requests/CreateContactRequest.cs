namespace Mailtrap.Contacts.Requests;

/// <summary>
/// Request object for creating a contact.
/// </summary>
public sealed record CreateContactRequest : ContactRequest
{
    /// <summary>
    /// Gets contact list IDs.
    /// </summary>
    ///
    /// <value>
    /// Contact list IDs.
    /// </value>
    [JsonPropertyName("list_ids")]
    public IList<int> ListIds { get; } = [];

    /// <inheritdoc />
    public CreateContactRequest(string email) : base(email) { }

    /// <summary>
    /// Parameterless instance constructor for serializers.
    /// </summary>
    [JsonConstructor]
    public CreateContactRequest() { }
}
