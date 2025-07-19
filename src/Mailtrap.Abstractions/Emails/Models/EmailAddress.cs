namespace Mailtrap.Emails.Models;


/// <summary>
/// Represents sender's or recipient's email address and name tuple, that can be used in From, To, CC or BCC parameters.
/// </summary>
public record EmailAddress
{
    /// <summary>
    /// <para>
    /// Gets sender's or recipient's email address.
    /// </para>
    /// <para>
    /// Required. Must be valid email address.
    /// </para>
    /// </summary>
    ///
    /// <value>
    /// Contains sender's or recipient's email address.
    /// </value>    
    [JsonPropertyName("email")]
    [JsonPropertyOrder(1)]
    public string Email { get; }

    /// <summary>
    /// <para>
    /// Gets sender's or recipient's display name.
    /// </para>
    /// <para>
    /// Optional.
    /// </para>
    /// </summary>
    /// 
    /// <value>
    /// Contains sender's or recipient's display name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(2)]
    public string? DisplayName { get; }


    /// <summary>
    /// Default instance constructor.
    /// </summary>
    /// 
    /// <param name="email">
    /// <para>
    /// Sender's or recipient's email address.
    /// </para>
    /// <para>
    /// Required. Must be valid email address.
    /// </para>
    /// </param>
    /// 
    /// <param name="displayName">
    /// Optional sender's or recipient's display name.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When <paramref name="email"/> is <see langword="null"/> or <see cref="string.Empty"/>.
    /// </exception>
    public EmailAddress(string email, string? displayName = default)
    {
        Ensure.NotNullOrEmpty(email, nameof(email));

        Email = email;
        DisplayName = displayName;
    }
}
