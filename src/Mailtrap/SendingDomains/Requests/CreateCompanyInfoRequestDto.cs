namespace Mailtrap.SendingDomains.Requests;


/// <summary>
/// Request DTO that wraps <see cref="CreateCompanyInfoRequest"/> in the <c>company_info</c> envelope expected by the API.
/// </summary>
internal sealed record CreateCompanyInfoRequestDto : IValidatable
{
    [JsonPropertyName("company_info")]
    [JsonPropertyOrder(1)]
    public CreateCompanyInfoRequest CompanyInfo { get; }


    public CreateCompanyInfoRequestDto(CreateCompanyInfoRequest companyInfo)
    {
        Ensure.NotNull(companyInfo, nameof(companyInfo));

        CompanyInfo = companyInfo;
    }


    public ValidationResult Validate() => CompanyInfo.Validate();
}
