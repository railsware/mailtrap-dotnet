namespace Mailtrap.SendingDomains.Requests;


/// <summary>
/// Request object for creating company information for a sending domain.
/// </summary>
public sealed record CreateCompanyInfoRequest : IValidatable
{
    /// <summary>
    /// Gets or sets company or individual name.
    /// </summary>
    ///
    /// <value>
    /// Company or individual name.
    /// </value>
    [JsonPropertyName("name")]
    [JsonPropertyOrder(1)]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets street address.
    /// </summary>
    ///
    /// <value>
    /// Street address.
    /// </value>
    [JsonPropertyName("address")]
    [JsonPropertyOrder(2)]
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets city.
    /// </summary>
    ///
    /// <value>
    /// City.
    /// </value>
    [JsonPropertyName("city")]
    [JsonPropertyOrder(3)]
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets country.
    /// </summary>
    ///
    /// <value>
    /// Country.
    /// </value>
    [JsonPropertyName("country")]
    [JsonPropertyOrder(4)]
    public string? Country { get; set; }

    /// <summary>
    /// Gets or sets ZIP or postal code.
    /// </summary>
    ///
    /// <value>
    /// ZIP or postal code.
    /// </value>
    [JsonPropertyName("zip_code")]
    [JsonPropertyOrder(5)]
    public string? ZipCode { get; set; }

    /// <summary>
    /// Gets or sets company website URL.
    /// </summary>
    ///
    /// <value>
    /// Company website URL.
    /// </value>
    [JsonPropertyName("website_url")]
    [JsonPropertyOrder(6)]
    public Uri? WebsiteUrl { get; set; }

    /// <summary>
    /// Gets or sets phone number.
    /// </summary>
    ///
    /// <value>
    /// Phone number, or <see langword="null"/> to omit.
    /// </value>
    [JsonPropertyName("phone")]
    [JsonPropertyOrder(7)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets URL of the privacy policy page.
    /// </summary>
    ///
    /// <value>
    /// URL of the privacy policy page, or <see langword="null"/> to omit.
    /// </value>
    [JsonPropertyName("privacy_policy_url")]
    [JsonPropertyOrder(8)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Uri? PrivacyPolicyUrl { get; set; }

    /// <summary>
    /// Gets or sets URL of the terms of service page.
    /// </summary>
    ///
    /// <value>
    /// URL of the terms of service page, or <see langword="null"/> to omit.
    /// </value>
    [JsonPropertyName("terms_of_service_url")]
    [JsonPropertyOrder(9)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Uri? TermsOfServiceUrl { get; set; }

    /// <summary>
    /// Gets or sets whether the sender is a business or an individual.
    /// </summary>
    ///
    /// <value>
    /// Sender info level, or <see langword="null"/> to omit.
    /// </value>
    [JsonPropertyName("info_level")]
    [JsonPropertyOrder(10)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CompanyInfoLevel? InfoLevel { get; set; }


    /// <inheritdoc/>
    public ValidationResult Validate()
    {
        return CreateCompanyInfoRequestValidator.Instance
            .Validate(this)
            .ToMailtrapValidationResult();
    }
}
