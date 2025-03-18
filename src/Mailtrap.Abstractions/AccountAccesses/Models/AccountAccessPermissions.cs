namespace Mailtrap.AccountAccesses.Models;


/// <summary>
/// Represents access permissions for the account.
/// </summary>
public sealed record AccountAccessPermissions
{
    /// <summary>
    /// Gets the flag indicating whether specifier can read account.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if specifier can read account.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_read")]
    [JsonPropertyOrder(1)]
    public bool? CanRead { get; set; }

    /// <summary>
    /// Gets the flag indicating whether specifier can update account.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if specifier can update account.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_update")]
    [JsonPropertyOrder(2)]
    public bool? CanUpdate { get; set; }

    /// <summary>
    /// Gets the flag indicating whether specifier can destroy account.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if specifier can destroy account.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_destroy")]
    [JsonPropertyOrder(3)]
    public bool? CanDestroy { get; set; }

    /// <summary>
    /// Gets the flag indicating whether specifier can leave account.
    /// </summary>
    ///
    /// <value>
    /// <see langword="true"/> if specifier can leave account.<br />
    /// <see langword="false"/> otherwise.
    /// </value>
    [JsonPropertyName("can_leave")]
    [JsonPropertyOrder(4)]
    public bool? CanLeave { get; set; }
}
