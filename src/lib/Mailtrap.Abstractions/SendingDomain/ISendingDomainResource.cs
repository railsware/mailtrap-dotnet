// -----------------------------------------------------------------------
// <copyright file="ISendingDomainResource.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.SendingDomain;


/// <summary>
/// Represents sending domain resource.
/// </summary>
public interface ISendingDomainResource
{
    /// <summary>
    /// Gets domain data and status of sending domain, represented by this resource instance.
    /// </summary>
    /// 
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> instance to control operation cancellation.
    /// </param>
    /// 
    /// <returns>
    /// Response containing domain attributes, DNS records, status, etc. for domain.
    /// </returns>
    public Task<Response<SendingDomainDetails>> GetDetails(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends setup instructions for sending domain, represented by this resource instance,
    /// to the recipient specified by <paramref name="request"/>.
    /// </summary>
    /// 
    /// <param name="request">
    /// Request containing recipient details to send setup instructions to.
    /// </param>
    ///
    /// <param name="cancellationToken">
    /// <inheritdoc cref="GetDetails(CancellationToken)" path="/param[@name='cancellationToken']"/>
    /// </param>
    /// 
    /// <returns>
    /// <see cref="Task"/> instance, representing the operation completion.
    /// </returns>
    public Task SendInstructions(SendingDomainInstructionsRequest request, CancellationToken cancellationToken = default);
}
