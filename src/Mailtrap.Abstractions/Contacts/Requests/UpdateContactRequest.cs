namespace Mailtrap.Contacts.Requests;

/// <summary>
/// Request object for updating a contact.
/// </summary>
public sealed record UpdateContactRequest : ContactImportRequest
{
    /// <summary>
    /// Gets contact "unsubscribed" status.
    /// </summary>
    ///
    /// <value>
    /// Contact "unsubscribed" status.
    /// </value>
    [JsonPropertyName("unsubscribed")]
    public bool? Unsubscribed { get; set; }

    /// <inheritdoc />
    public UpdateContactRequest(string email) : base(email) { }

    /// <summary>
    /// Parameterless instance constructor for serializers.
    /// </summary>
    public UpdateContactRequest() { }
}
