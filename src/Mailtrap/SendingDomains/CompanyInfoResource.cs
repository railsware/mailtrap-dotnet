namespace Mailtrap.SendingDomains;


internal sealed class CompanyInfoResource : RestResource, ICompanyInfoResource
{
    public CompanyInfoResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<CompanyInfo> GetDetails(CancellationToken cancellationToken = default)
    {
        var response = await Get<CompanyInfoResponseDto>(cancellationToken).ConfigureAwait(false);

        return response.CompanyInfo;
    }

    public async Task<CompanyInfo> Create(CreateCompanyInfoRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var response = await Create<CreateCompanyInfoRequestDto, CompanyInfoResponseDto>(request.ToDto(), cancellationToken).ConfigureAwait(false);

        return response.CompanyInfo;
    }

    public async Task<CompanyInfo> Update(UpdateCompanyInfoRequest request, CancellationToken cancellationToken = default)
    {
        Ensure.NotNull(request, nameof(request));

        var response = await Update<UpdateCompanyInfoRequestDto, CompanyInfoResponseDto>(request.ToDto(), cancellationToken).ConfigureAwait(false);

        return response.CompanyInfo;
    }
}
