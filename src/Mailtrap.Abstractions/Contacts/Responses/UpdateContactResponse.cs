namespace Mailtrap.Contacts.Responses;

/// <summary>
/// Response object for contact update.
/// </summary>
public sealed record UpdateContactResponse : ContactResponse
{
    /// <summary>
    /// Gets the action performed on the contact.
    /// </summary>
    ///
    /// <value>
    /// "created" if contact does not exist,
    /// "updated" if contact already exists.
    /// </value>
    [JsonPropertyName("action")]
    public ContactAction Action { get; set; } = ContactAction.Unknown;
}
