// -----------------------------------------------------------------------
// <copyright file="ISendingDomainCollectionResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomains;


/// <summary>
/// Represents sending domain collection resource.
/// </summary>
public interface ISendingDomainCollectionResource : IRestResource
{
    /// <summary>
    /// Gets sending domains and their statuses.
    /// </summary>
    ///
    /// <param name="cancellationToken">
    /// Token to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Collection of sending domain details.
    /// </returns>
    public Task<IList<SendingDomain>> GetAll(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates new sending domain with details specified by <paramref name="request"/>.
    /// </summary>
    /// 
    /// <param name="request">
    /// Request containing sending domain details for creation.
    /// </param>
    /// 
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetAll(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// Created sending domain details.
    /// </returns>
    public Task<SendingDomain> Create(CreateSendingDomainRequest request, CancellationToken cancellationToken = default);
}
