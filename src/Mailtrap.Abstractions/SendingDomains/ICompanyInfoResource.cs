namespace Mailtrap.SendingDomains;


/// <summary>
/// Represents company info resource of a sending domain.
/// </summary>
public interface ICompanyInfoResource : IRestResource
{
    /// <summary>
    /// Gets company info associated with the sending domain, represented by this resource instance.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    ///
    /// <returns>
    /// Company info of the sending domain.
    /// </returns>
    public Task<CompanyInfo> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates company info for the sending domain, represented by this resource instance.<br/>
    /// Company info is required for domain compliance verification.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing company info details.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Created company info.
    /// </returns>
    public Task<CompanyInfo> Create(CreateCompanyInfoRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates company info of the sending domain, represented by this resource instance.
    /// </summary>
    ///
    /// <param name="request">
    /// Request containing company info details to update. Only properties set on the request are sent.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    ///
    /// <returns>
    /// Updated company info.
    /// </returns>
    public Task<CompanyInfo> Update(UpdateCompanyInfoRequest request, CancellationToken cancellationToken = default);
}
