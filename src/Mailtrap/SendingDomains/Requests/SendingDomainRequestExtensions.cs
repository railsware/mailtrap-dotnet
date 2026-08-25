namespace Mailtrap.SendingDomains.Requests;


internal static class SendingDomainRequestExtensions
{
    public static CreateSendingDomainRequestDto ToDto(this CreateSendingDomainRequest request)
    {
        return new CreateSendingDomainRequestDto
        {
            Domain = request
        };
    }

    public static UpdateSendingDomainRequestDto ToDto(this UpdateSendingDomainRequest request) => new(request);

    public static CreateCompanyInfoRequestDto ToDto(this CreateCompanyInfoRequest request) => new(request);

    public static UpdateCompanyInfoRequestDto ToDto(this UpdateCompanyInfoRequest request) => new(request);

    public static IList<SendingDomain> FromDto(this GetAllSendingDomainResponseDto response)
    {
        return response.Domains;
    }
}
