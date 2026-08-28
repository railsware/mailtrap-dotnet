namespace Mailtrap.ApiTokens.Requests;


/// <summary>
/// Request to reset an API token.
/// </summary>
public sealed record ResetApiTokenRequest
{
    /// <summary>
    /// Gets or sets the optional expiration for the new token.
    /// </summary>
    ///
    /// <value>
    /// Optional token expiration as an ISO 8601 date-time.<br/>
    /// Omit for the server default (a 1-year default is being rolled out).<br/>
    /// Use <see cref="ApiTokenExpiration.Never"/> for a token that never expires.<br/>
    /// Past or more-than-5-years-ahead values are rejected with 422.
    /// </value>
    [JsonPropertyName("expires_at")]
    [JsonPropertyOrder(1)]
    public ApiTokenExpiration? ExpiresAt { get; set; }
}
