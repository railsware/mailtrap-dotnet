namespace Mailtrap.ApiTokens.Requests;


/// <summary>
/// Request to create a new API token.
/// </summary>
public sealed record CreateApiTokenRequest : IValidatable
{
    /// <summary>
    /// Gets or sets the API token display name.
    /// </summary>
    ///
    /// <value>
    /// API token display name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    [JsonRequired]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the optional token expiration.
    /// </summary>
    ///
    /// <value>
    /// Optional token expiration as an ISO 8601 date-time.<br/>
    /// Omit for the server default (a 1-year default is being rolled out).<br/>
    /// Use <see cref="ApiTokenExpiration.Never"/> for a token that never expires.<br/>
    /// Past or more-than-5-years-ahead values are rejected with 422.
    /// </value>
    [JsonPropertyName("expires_at")]
    [JsonPropertyOrder(2)]
    public ApiTokenExpiration? ExpiresAt { get; set; }

    /// <summary>
    /// Gets the resource accesses to grant to the API token.
    /// </summary>
    ///
    /// <value>
    /// Collection of resource accesses.
    /// </value>
    [JsonPropertyName("resources")]
    [JsonPropertyOrder(3)]
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public IList<ApiTokenAccessRequest> Resources { get; } = [];


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return CreateApiTokenRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
