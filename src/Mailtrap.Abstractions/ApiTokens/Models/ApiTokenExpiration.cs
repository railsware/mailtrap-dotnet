namespace Mailtrap.ApiTokens.Models;


/// <summary>
/// Represents an explicit API token expiration, serialized as an ISO 8601 date-time.<br/>
/// Leave the request property unset to omit the value and get the server default
/// (a 1-year default is being rolled out).<br/>
/// Use <see cref="Never"/> for a token that never expires.<br/>
/// Past or more-than-5-years-ahead values are rejected with 422.
/// </summary>
[JsonConverter(typeof(ApiTokenExpirationJsonConverter))]
public sealed record ApiTokenExpiration
{
    /// <summary>
    /// Gets the expiration for a token that never expires.
    /// </summary>
    ///
    /// <value>
    /// Expiration for a token that never expires. Serialized as JSON <see langword="null"/>.
    /// </value>
    public static ApiTokenExpiration Never { get; } = new((DateTimeOffset?)null);


    /// <summary>
    /// Creates an expiration at the provided date and time.
    /// </summary>
    ///
    /// <param name="value">
    /// Date and time when the token expires.
    /// </param>
    ///
    /// <returns>
    /// Expiration at the provided date and time. Serialized as an ISO 8601 date-time string.
    /// </returns>
    public static ApiTokenExpiration At(DateTimeOffset value) => new(value);


    /// <summary>
    /// Gets the expiration date and time,
    /// or <see langword="null"/> for a token that never expires.
    /// </summary>
    ///
    /// <value>
    /// Expiration date and time, or <see langword="null"/> for a token that never expires.
    /// </value>
    internal DateTimeOffset? Value { get; }


    private ApiTokenExpiration(DateTimeOffset? value)
    {
        Value = value;
    }
}
