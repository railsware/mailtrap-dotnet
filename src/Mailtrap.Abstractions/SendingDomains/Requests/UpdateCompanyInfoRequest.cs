namespace Mailtrap.SendingDomains.Requests;


/// <summary>
/// Request object for updating company information for a sending domain.
/// Only properties set on the request are sent.
/// </summary>
public sealed record UpdateCompanyInfoRequest
{
    /// <summary>
    /// Gets or sets company or individual name.
    /// </summary>
    ///
    /// <value>
    /// Company or individual name, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets street address.
    /// </summary>
    ///
    /// <value>
    /// Street address, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("address")]
    [JsonPropertyOrder(2)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets city.
    /// </summary>
    ///
    /// <value>
    /// City, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("city")]
    [JsonPropertyOrder(3)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets country.
    /// </summary>
    ///
    /// <value>
    /// Country, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("country")]
    [JsonPropertyOrder(4)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Country { get; set; }

    /// <summary>
    /// Gets or sets phone number.
    /// </summary>
    ///
    /// <value>
    /// Phone number, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("phone")]
    [JsonPropertyOrder(5)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets ZIP or postal code.
    /// </summary>
    ///
    /// <value>
    /// ZIP or postal code, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("zip_code")]
    [JsonPropertyOrder(6)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ZipCode { get; set; }

    /// <summary>
    /// Gets or sets URL of the privacy policy page.
    /// </summary>
    ///
    /// <value>
    /// URL of the privacy policy page, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("privacy_policy_url")]
    [JsonPropertyOrder(7)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Uri? PrivacyPolicyUrl { get; set; }

    /// <summary>
    /// Gets or sets URL of the terms of service page.
    /// </summary>
    ///
    /// <value>
    /// URL of the terms of service page, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("terms_of_service_url")]
    [JsonPropertyOrder(8)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Uri? TermsOfServiceUrl { get; set; }

    /// <summary>
    /// Gets or sets company website URL.
    /// </summary>
    ///
    /// <value>
    /// Company website URL, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("website_url")]
    [JsonPropertyOrder(9)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Uri? WebsiteUrl { get; set; }

    /// <summary>
    /// Gets or sets whether the sender is a business or an individual.
    /// </summary>
    ///
    /// <value>
    /// Sender info level, or <see langword="null"/> to leave unchanged.
    /// </value>
    [JsonPropertyName("info_level")]
    [JsonPropertyOrder(10)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CompanyInfoLevel? InfoLevel { get; set; }
}
