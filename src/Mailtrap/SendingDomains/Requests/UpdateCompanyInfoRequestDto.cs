namespace Mailtrap.SendingDomains.Requests;


/// <summary>
/// Request DTO that wraps <see cref="UpdateCompanyInfoRequest"/> in the <c>company_info</c> envelope expected by the API.
/// </summary>
internal sealed record UpdateCompanyInfoRequestDto
{
    [JsonPropertyName("company_info")]
    [JsonPropertyOrder(1)]
    public UpdateCompanyInfoRequest CompanyInfo { get; }


    public UpdateCompanyInfoRequestDto(UpdateCompanyInfoRequest companyInfo)
    {
        Ensure.NotNull(companyInfo, nameof(companyInfo));

        CompanyInfo = companyInfo;
    }
}
